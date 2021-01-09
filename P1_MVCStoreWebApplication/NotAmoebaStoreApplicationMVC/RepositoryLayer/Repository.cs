using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModelLayer;

namespace RepositoryLayer
{
    public class Repository {
        private StoreAppDBContext _dbContext;
        DbSet<Customer> customers;
        public Repository(StoreAppDBContext dbContextClass)
            {
                _dbContext = dbContextClass;
                this.customers = _dbContext.customers;
            }

        public Customer LoginCustomer(Customer c)

        {
            Customer customer1 = customers.FirstOrDefault(x => x.UserName == c.UserName);// check if the player is in the Db

            if (customer1 == null)// create new player if none exists
            {
                customer1 = new Customer()
                {
                    FName = c.FName,
                    LName = c.LName,
                    UserName = c.UserName
                };
                customers.Add(customer1);// ass new player
                _dbContext.SaveChanges();// save new player to Db

                try
                {
                    Customer customer2 = customers.FirstOrDefault(x => x.UserName == customer1.UserName);// check if the player is in the Db
                    return customer2;
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine("Saving player to DB threw an error" , ex);
                    //_logger.LogInformation($"Saving a player to the Db threw an error, {ex}");
                }
            }
            return customer1;
        }
        //{
        //    Customer c1 = customers.Where(x => x.UserName == c.UserName).FirstOrDefault();
        //    Console.WriteLine(c1);
        //    //if (c1 == null) // new player
        //    //{
        //    //    c1 = new Customer(c.FName, c.LName, c.UserName);
        //    //    customers.Add(c1);
        //    //    _dbContext.SaveChanges();
        //    //}
        //    //return c1;
        //    if (c1 != null) //found player
        //    {
        //        return c1;
        //    }
        //    else
        //    {
        //        Customer c2 = new Customer("generated", "for", "you");
        //        return c2;
        //    }
        //}
    }
}
