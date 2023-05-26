using Microsoft.EntityFrameworkCore;
using Orders.Model;

namespace Orders.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base (options)
        {
            
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
