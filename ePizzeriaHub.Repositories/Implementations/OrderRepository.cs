using ePizzeriaHub.Entities;
using ePizzeriaHub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzeriaHub.Repositories.Implementations
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private AppDBContext dbContext
        {
            get
            {
                return dbContext as AppDBContext;
            }
        }
        public OrderRepository(AppDBContext dbContext): base(dbContext)
        {
            
        }
        public IEnumerable<Order> GetUserOrders(int userId) => dbContext.Orders
               .Include(o => o.OrderItems)
               .Where(x => x.UserId == userId).ToList();
    }
}
