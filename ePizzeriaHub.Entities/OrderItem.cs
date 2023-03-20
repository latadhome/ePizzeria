using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzeriaHub.Entities
{
    public class OrderItem
    {
        private OrderItem() { }
        public OrderItem( int itemId, decimal unitPrice, int quantity, decimal total)
        {
            this.ItemId = itemId;
            this.UnitPrice = unitPrice;                
            this.Quantity = quantity;
            this.Total = total;
            
        }
        public int Id { get; set; }
        public int ItemId { get; set; }
        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }


    }
}
