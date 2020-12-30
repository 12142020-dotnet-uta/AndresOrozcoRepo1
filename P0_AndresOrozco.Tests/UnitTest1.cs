using System;
using P0_AndresOrozco;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace P0_AndresOrozco.Tests
{
    public class UnitTest1
    {
        [Fact]
        /// <summary>
        /// Tests whether a customer was created and sent to the DB. Retreives it and compares its result with local
        /// object.
        /// </summary>
        public void CreatingCustomerTest()
        {
            //arrange
            var options = new DbContextOptionsBuilder<StoreAppDBContext>().UseInMemoryDatabase(databaseName: "TestDb").Options;

            //add
            using (var context = new StoreAppDBContext(options)) //might cause
            //problems bc i have no constructor that just takes option
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                StoreAppRepositoryLayer repo = new StoreAppRepositoryLayer(context);
                repo.CreateCustomer("fname", "lname", "username");
                context.SaveChanges();
            }

            using (var context = new StoreAppDBContext(options))
            {
                StoreAppRepositoryLayer repo = new StoreAppRepositoryLayer(context);
                int status = repo.CreateCustomer("fname", "lname", "username");
                if (status == 0) //created customer
                {
                    Customer fromDB = context.customers.Find("username");
                    Assert.True(fromDB.Equals("username"));
                }

            }

        }

        [Fact]
        /// <summary>
        /// Will look for nonexistent player in DB. Should return 0 if found, will return -1 to show it 
        /// looked through DB and found did not find it.
        ///  </summary>
        public void LogInTest()
        {
            //arrange
            var options = new DbContextOptionsBuilder<StoreAppDBContext>().UseInMemoryDatabase(databaseName: "TestDb").Options;

            //add
            using (var context = new StoreAppDBContext(options)) //might cause
            //problems bc i have no constructor that just takes option
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                StoreAppRepositoryLayer repo = new StoreAppRepositoryLayer(context);
                int status = repo.LogIn("I_AM_NON_EXISTENT");
                Assert.Equal(status, -1);
            }
        }
    }
}
