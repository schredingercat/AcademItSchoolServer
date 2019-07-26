using System.Data.Entity;

namespace ShopEf.Models
{
    public class ShopContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public ShopContext() : base("DefaultConnection")
        {

        }
    }
}
