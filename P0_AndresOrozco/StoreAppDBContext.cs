using System;
using Microsoft.EntityFrameworkCore;
//using System.ComponentModel.DataAnnotations;


namespace P0_AndresOrozco
{
    public class StoreAppDBContext : DbContext
    {
        public DbSet<User> users {get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=StoreApplication;Trusted_Connection=True;");
            //options.UseSqlServer(@"Server=localhost\\SQLEXPRESS02;Database=RpsGame12142020;Trusted_Connection=True;");

        }
    }
}