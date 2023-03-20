using ePizzeriaHub.Entities;
using ePizzeriaHub.Services.Implementations;
using ePizzeriaHub.Services.Interfaces;
using ePizzeriaHub.WebUI.Interfaces;
using ePizzeriaHub.WebUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml;

namespace ePizzeriaHub.WebUI.Areas.Admin.Controllers
{
    public class ItemController : BaseController
    {
        ICatalogService _catalogService;
        IFileHelper _fileHelper;
        IConfiguration _config;
        IPizzeriaService _pizzeriaService;
        public ItemController(ICatalogService catalogService, IConfiguration config, IFileHelper fileHelper, IUserAccessor userAccessor, IPizzeriaService pizzeria) : base(userAccessor)
        {
            _catalogService = catalogService;
            _config = config;
            _fileHelper = fileHelper;
            _pizzeriaService = pizzeria;
        }

        public IActionResult Items()
        {
            var data = _catalogService.GetItems();
            return View(data);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _catalogService.GetCategories();
            ViewBag.ItemTypes = _catalogService.GetItemTypes();
            ViewBag.Pizzerias = _pizzeriaService.GetPizzerias();
            return View();
        }

        [HttpPost]
        public IActionResult Create(ItemModel model)
        {
            try
            {
                model.ImageUrl = _fileHelper.UploadFile(model.File);
                Item data = new Item
                {
                    Name = model.Name,
                    UnitPrice = model.UnitPrice,
                    CategoryId = model.CategoryId,
                    PizzeriaId = model.PizzeriaId,
                    ItemTypeId = model.ItemTypeId,
                    Description = model.Description,
                    ImageUrl = model.ImageUrl
                };

                _catalogService.AddItem(data);
                return RedirectToAction("Items");
            }
            catch (Exception ex)
            {

            }
            ViewBag.Categories = _catalogService.GetCategories();
            ViewBag.ItemTypes = _catalogService.GetItemTypes();
            return View();
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Categories = _catalogService.GetCategories();
            ViewBag.ItemTypes = _catalogService.GetItemTypes();
            ViewBag.Pizzerias = _pizzeriaService.GetPizzerias();
            var data = _catalogService.GetItem(id);
            ItemModel model = new ItemModel
            {
                Id = data.Id,
                Name = data.Name,
                UnitPrice = data.UnitPrice,
                CategoryId = data.CategoryId,
                PizzeriaId=data.PizzeriaId,
                ItemTypeId = data.ItemTypeId,
                Description = data.Description,
                ImageUrl = data.ImageUrl
            };
            return View("Create", model);
        }

        [HttpPost]
        public IActionResult Edit(ItemModel model)
        {
            try
            {
                if (model.File != null)
                {
                    _fileHelper.DeleteFile(model.ImageUrl);
                    model.ImageUrl = _fileHelper.UploadFile(model.File);
                }

                Item data = new Item
                {
                    Id = model.Id,
                    Name = model.Name,
                    UnitPrice = model.UnitPrice,
                    CategoryId = model.CategoryId,
                    PizzeriaId=model.PizzeriaId,
                    ItemTypeId = model.ItemTypeId,
                    Description = model.Description,
                    ImageUrl = model.ImageUrl
                };

                _catalogService.UpdateItem(data);
                return RedirectToAction("Items");
            }
            catch (Exception ex)
            {

            }
            ViewBag.Categories = _catalogService.GetCategories();
            ViewBag.ItemTypes = _catalogService.GetItemTypes();
            return View("Create", model);
        }

        [Route("~/Admin/Item/Delete/{id}/{url}")]
        public IActionResult Delete(int id, string url)
        {
            url = url.Replace("%2F", "/"); //replace to find the file
            _catalogService.DeleteItem(id);
            _fileHelper.DeleteFile(url);
            return RedirectToAction("Items");
        }
    }
}
