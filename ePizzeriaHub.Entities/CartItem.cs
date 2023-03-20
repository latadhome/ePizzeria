using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ePizzeriaHub.Entities
{
    public class CartItem
    {
        public CartItem()
        {
            
        }

        public CartItem(int itemId, int quantity, decimal unitPrice)
        {
            ItemId = itemId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
        public int Id { get; set; }
        public Guid CartId { get; set; }

        public int ItemId { get; private set; } // Read-Only can be only set using constructor

        public decimal UnitPrice { get; set; } // Read-Only can be only set using constructor

        public int Quantity { get; set; }

       [JsonIgnore]
        public Cart Cart { get; set; }
    }
}
