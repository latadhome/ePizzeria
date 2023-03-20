using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzeriaHub.Entities
{
    public class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }
        public int Id { get; set; }
        public int UserId { get; set; }

       // public int paymentId { get; set; } // not applicable for this assignment

        public string Street { get; set; }
        public string Zipcode { get; set; }

        public string City { get; set; }

        public DateTime CreatedDate { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        public string PhoneNumber { get; set; }

    }
}
