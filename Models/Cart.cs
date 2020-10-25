using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneShoppingList.Models
{
    public class Cart
    {
        public List<OrderProduct> Products { get; set; } = new List<OrderProduct>();

        public decimal Total { get; set; }

        public decimal Tax 
        {
            get { return Math.Round(Total * 0.06m, 2); } 
        } 

        public decimal SubTotal
        {
            get { return Total + Tax; }
        }
    }
}
