﻿using System;
using System.Collections.Generic;

namespace ShopEf.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
