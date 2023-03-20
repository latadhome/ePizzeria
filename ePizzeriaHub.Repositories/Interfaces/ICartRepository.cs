using ePizzeriaHub.Entities;
using ePizzeriaHub.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzeriaHub.Repositories.Interfaces
{
    public interface ICartRepository : IRepository<Cart>
    {
        Cart GetCart(Guid CartId);
        int DeleteItem(Guid cartId, int itemId);
        CartModel GetCartDetails(Guid CartId);
        int UpdateQuantity(Guid cartId, int itemId,  int quantity);

        int UpdateCart(Guid cartId, int userId);

    }
}
