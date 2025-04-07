using System.Data.Entity;

namespace Project_class
{
    public class OrderContext : DbContext
    {
        public OrderContext() : base("name=OrderContext")
        {
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}
