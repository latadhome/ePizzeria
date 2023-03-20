using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzeriaHub.Entities
{
    /// <summary>
    /// General Pizza Toppings. e.g. Cheese, Onion ..etc
    /// </summary>
    public class Toppings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal UnitPrice { get; set; }

    }
}
