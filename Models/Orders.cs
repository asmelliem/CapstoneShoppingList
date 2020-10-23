﻿using System;
using System.Collections.Generic;

namespace CapstoneShoppingList.Models
{
    public partial class Orders
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Total { get; set; }

        public virtual Products Product { get; set; }
    }
}
