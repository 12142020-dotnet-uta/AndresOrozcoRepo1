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
                return null;
            }
            return customer1;
        }
        public Customer RegisterCustomer(Customer c)
        {
            Customer customer1 = customers.FirstOrDefault(x => x.UserName == c.UserName);// check if the player is in the Db
            if (customer1 == null) //does not exist yet
            {
                Customer c1 = new Customer()
                {
                    FName = c.FName,
                    LName = c.LName,
                    UserName = c.UserName,
                    Store = c.Store
                };
                customers.Add(c1);
                _dbContext.SaveChanges();
                return c1;
            }
            else //exists! cannot register
            {
                return null;
            }
        }
        public List<Customer> CustomerList()
        {
            return customers.ToList();
        }
    }
}
