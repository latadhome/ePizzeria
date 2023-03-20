using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ePizzeriaHub.Entities
{
    public class CartToppings
    {
        public CartToppings() { }
        public CartToppings(int toppingId, decimal unitPrice, int quantity) 
        {
            ToppingId = toppingId;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }

        public int Id { get; set; }

        public int ToppingId { get; set; }

        public int CartItemId { get; set; }
        
        public decimal UnitPrice { get; set; } // Read-Only can be only set using constructor

        public int Quantity { get; set; }
    }
}
