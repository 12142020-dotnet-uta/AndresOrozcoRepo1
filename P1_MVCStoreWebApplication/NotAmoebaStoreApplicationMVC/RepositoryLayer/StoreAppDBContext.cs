using Microsoft.EntityFrameworkCore;
using ModelLayer;

namespace RepositoryLayer
{
    public class StoreAppDBContext : DbContext
    {
        public DbSet<Customer> customers { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Inventory> inventory { get; set; }
        public DbSet<Store> stores { get; set; }
        public DbSet<OrderHistory> orderHistory { get; set; }

        public StoreAppDBContext() { }
        public StoreAppDBContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=NotAmoebaDB;Trusted_Connection=True;MultipleActiveResultSets=true;");
            }
            //options.UseSqlServer(@"Server=localhost\\SQLEXPRESS02;Database=RpsGame12142020;Trusted_Connection=True;");
        }
    }
}
