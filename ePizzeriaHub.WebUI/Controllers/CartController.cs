﻿using ePizzeriaHub.Services.Interfaces;
using ePizzeriaHub.WebUI.Helpers;
using ePizzeriaHub.Entities;
using ePizzeriaHub.Repositories.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ePizzeriaHub.WebUI.Interfaces;
using ePizzeriaHub.WebUI.Models;

namespace ePizzeriaHub.WebUI.Controllers
{
    public class CartController : Controller
    {
        protected IUserAccessor _userAccessor;
        protected ICartService _cartService;
        protected ICatalogService _catalogService;
        public User CurrentUser
        {
            get
            {
                if (User != null)
                    return _userAccessor.GetUser();
                else
                    return null;
            }
        }
        Guid CartId
        {
            get
            {
                Guid Id;
                string CId = Request.Cookies["CId"];
                if (string.IsNullOrEmpty(CId))
                {
                    Id = Guid.NewGuid();
                    Response.Cookies.Append("CId", Id.ToString());
                }
                else
                {
                    Id = Guid.Parse(CId);
                }
                return Id;
            }
        }

        public CartController(IUserAccessor userAccessor, ICartService cartService, ICatalogService catalogService)
        {
            _userAccessor = userAccessor;
            _cartService = cartService;
            _catalogService = catalogService;
        }
        public IActionResult Index()
        {
            CartModel cart = _cartService.GetCartDetails(CartId);
            if (CurrentUser != null && cart != null)
            {
               // TempData.Set("Cart", cart);
                _cartService.UpdateCart(cart.Id, CurrentUser.Id);
            }
            return View(cart);
        }

        [Route("Cart/AddToCart/{ItemId}/{UnitPrice}/{Quantity}")]
        public IActionResult AddToCart(int ItemId, decimal UnitPrice, int Quantity)
        {
            int UserId = CurrentUser != null ? CurrentUser.Id : 0;

            if (ItemId > 0 && Quantity > 0)
            {
                Cart cart = _cartService.AddItem(UserId, CartId, ItemId, UnitPrice, Quantity);
                var data = JsonSerializer.Serialize(cart);
                return Json(data);
            }
            else
            {
                return Json("");
            }
        }

        public IActionResult GetCartCount()
        {
            int count = _cartService.GetCartCount(CartId);
            return Json(count);
        }

        [Route("Cart/UpdateQuantity/{Id}/{Quantity}")]
        public IActionResult UpdateQuantity(int Id, int Quantity)
        {
            int count = _cartService.UpdateQuantity(CartId, Id, Quantity);
            return Json(count);
        }

        [Route("Cart/UpdateToppingQuantity/{Id}/{Quantity}")]
        public IActionResult UpdateToppingQuantity(int Id, int Quantity)
        {
            int count = _cartService.UpdateQuantity(CartId, Id, Quantity);
            return Json(count);
        }

        public IActionResult DeleteItem(int Id)
        {
            int count = _cartService.DeleteItem(CartId, Id);
            return Json(count);
        }

        public IActionResult CheckOut()
        {
            return View();
        }

        public IActionResult AddPizza(int ItemId)
        {
            //TempData.Set("Address", address);
            var item = _catalogService.GetItem(ItemId);
            var Toppings = _catalogService.GetToppings();

            List<ToppingModel> toppingModel = new List<ToppingModel>();
            foreach(var topping in Toppings) 
            {
                ToppingModel model = new ToppingModel();
                model.Id = topping.Id;
                model.Name = topping.Name;
                model.UnitPrice = topping.UnitPrice;
                model.Quantity = 0;
                toppingModel.Add(model);
            }
            ViewBag.Toppings=toppingModel;

            return View(item);
            

        }
    }
}
