using System;
using Microsoft.EntityFrameworkCore;


namespace P0_AndresOrozco
{
    public class StoreAppDBContext : DbContext
    {
        public DbSet<Customer> customers {get; set;}
        public DbSet<Product> products {get; set;}
        public DbSet<Inventory> inventory {get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=NotAmoebaPreProduction;Trusted_Connection=True;");
            //options.UseSqlServer(@"Server=localhost\\SQLEXPRESS02;Database=RpsGame12142020;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //to create a composite key for Inventory
            modelBuilder.Entity<Inventory>().HasKey(c => new { c.StoreId, c.ProductId });
        }
    }
}