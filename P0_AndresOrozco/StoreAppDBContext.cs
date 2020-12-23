using System;
using Microsoft.EntityFrameworkCore;


namespace P0_AndresOrozco
{
    public class StoreAppDBContext : DbContext
    {
        public DbSet<Customer> customers {get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=StoreAppPreProduction;Trusted_Connection=True;");
            //options.UseSqlServer(@"Server=localhost\\SQLEXPRESS02;Database=RpsGame12142020;Trusted_Connection=True;");

        }
    }
}