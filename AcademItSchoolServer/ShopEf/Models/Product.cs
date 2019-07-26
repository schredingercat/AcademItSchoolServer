using System.Collections.Generic;

namespace ShopEf.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
