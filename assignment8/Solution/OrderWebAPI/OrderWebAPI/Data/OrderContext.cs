using System.Data.Entity;
using OrderWebAPI.Models;

namespace OrderWebAPI.Data
{
    public class OrderContext : DbContext
    {
        public OrderContext() : base("name=OrderContext") { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}
