using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneShoppingList.Models
{
    public class OrderProduct
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public decimal Total
        {
            get { return Price * Quantity; }
        }
    }
}
