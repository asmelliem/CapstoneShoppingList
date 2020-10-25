using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneShoppingList.Models
{
    public class OrderItem
    {
        public List<Products> Products { get; set; }

        public int? Orderid { get; set; }
    }
}
