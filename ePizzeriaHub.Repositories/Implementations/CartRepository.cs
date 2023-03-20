using ePizzeriaHub.Entities;
using ePizzeriaHub.Repositories.Interfaces;
using ePizzeriaHub.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzeriaHub.Repositories.Implementations
{
    /// <summary>
    /// This Specific Class will retrive Cart details along with Items 
    /// </summary>
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        private AppDBContext dbContext {
            get
            {
                return _dbContext as AppDBContext;
            }
        }
        public CartRepository(DbContext dbContext):base(dbContext)
        {
            //_dbContext = dbContext;
        }
        public Cart GetCart(Guid CartId)
        {
            return dbContext.Carts.Include("Items").Where(c => c.Id == CartId && c.IsActive == true).FirstOrDefault(); 
        }

        public CartModel GetCartDetails(Guid CartId)
        {
            var model = (from cart in dbContext.Carts
                         where cart.Id == CartId && cart.IsActive == true
                         select new CartModel
                         {
                             Id = cart.Id,
                             UserId = cart.UserId,
                             CreatedDate = cart.CreatedDate,
                             Items = (from cartItem in dbContext.CartItems
                                      join item in dbContext.Items
                                      on cartItem.ItemId equals item.Id
                                      where cartItem.CartId == CartId
                                      select new ItemModel
                                      {
                                          Id = cartItem.Id,
                                          Name = item.Name,
                                          Description = item.Description,
                                          ImageUrl = item.ImageUrl,
                                          Quantity = cartItem.Quantity,
                                          ItemId = item.Id,
                                          UnitPrice = cartItem.UnitPrice
                                      }).ToList()
                         }).FirstOrDefault();
            return model;
        }
        public int DeleteItem(Guid cartId, int itemId)
        {
            var item = dbContext.CartItems.Where(c => c.CartId == cartId && c.Id == itemId).FirstOrDefault();
            if (item != null)
            {
                dbContext.CartItems.Remove(item);
                return dbContext.SaveChanges();
            }
            else
                return 0;
        }

        public int UpdateQuantity(Guid cartId, int itemId, int quantity)
        {
            bool flag = false;
            var cart = GetCart(cartId);
            if (cart != null)
            {
                for (int i = 0; i < cart.Items.Count; i++)
                {
                    if (cart.Items[i].Id == itemId)
                    {
                        flag = true;
                        
                        if (quantity < 0 && cart.Items[i].Quantity > 1)//for minus quantity
                            cart.Items[i].Quantity += (quantity);
                        else if (quantity > 0)
                            cart.Items[i].Quantity += (quantity);
                        break;
                    }
                }
                if (flag)
                    return dbContext.SaveChanges();
            }
            return 0;

        }

        public int UpdateCart(Guid cartId, int userId)
        {
            Cart cart = GetCart(cartId);
            cart.UserId = userId;
            return dbContext.SaveChanges();
        }
    }
}
