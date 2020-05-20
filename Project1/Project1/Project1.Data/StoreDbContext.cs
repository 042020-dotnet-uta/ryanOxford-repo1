using Microsoft.EntityFrameworkCore;

namespace Project1.Data
{
    public class StoreDbContext: DbContext
    {
        public StoreDbContext() { }

        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Location> Locations { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<TempOrder> TempOrders { get; set; }
        public DbSet<TempOrderProduct> TempOrderProducts { get; set; }
    }
}
