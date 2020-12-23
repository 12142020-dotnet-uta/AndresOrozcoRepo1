using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

namespace P0_AndresOrozco
{
    public class StoreAppRepositoryLayer
    {
        static StoreAppDBContext db = new StoreAppDBContext();
        //DbSet<Customer> users = StoreAppDBContext.users;
        DbSet<Customer> users = db.customers;
        public Customer LogIn(string userName)
        {
            //fetch if username exists
            //then create Customer() object with return value
            /*
            User u = new User(userId);
            u = db.users.Where(x => x.UserId == Guid.Parse(userId)).FirstOrDefault();
            if (u == null)
            {
                //user doesn't exist!
                //db.Add(u);
                //db.SaveChanges();
            }
            else
            {

            }
            return u;
            */
            return new Customer("null", "null", "null");
        }
        public Customer CreateCustomer(string fName, string lName, string userName)
        {
            //Customer temp = db.users.Where(x => x.CustomerId == userId).FirstOrDefault();
            //Customer temp = (Customer)db.users.Where(x => x.CustomerId == Guid.Parse(userId)).FirstOrDefault();
            //Customer u = new Customer(fName, lName, userId);
            //u = db.users.Where(u => u.CustomerId == userId).FirstOrDefault();

            Customer u1 = new Customer("null", "null", "null");
            while (true){
            Console.WriteLine("im here");
            //u1 = users.Where(x => x.CustomerId.ToString() == Guid.Parse(userId).ToString()).FirstOrDefault();
            u1 = users.Where(x => x.UserName == userName).FirstOrDefault();//x => x.FName == fName && x.LName == lName).FirstOrDefault();
            Console.WriteLine($"{u1}");
            if (u1 == null)
            {
                u1 = new Customer(fName, lName, userName);//, Guid.Parse(userId).ToString());
                users.Add(u1);
                db.SaveChanges();
                Console.WriteLine("Wrote to Server");
                break;
            }
            else
            {
                return u1;//delte this beofre going on
                //username is taken.
                //ask for a new one

            }
            }
            return u1;
        }

    }
}