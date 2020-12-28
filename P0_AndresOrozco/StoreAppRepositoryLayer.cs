using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

namespace P0_AndresOrozco
{
    public class StoreAppRepositoryLayer
    {
        public Customer u1 = new Customer("null", "null", "null");
        public Inventory i1 = new Inventory(Guid.NewGuid(),-1, "null", -1);
        static StoreAppDBContext db = new StoreAppDBContext();
        //DbSet<Customer> users = StoreAppDBContext.users;
        DbSet<Customer> customers = db.customers;
        DbSet<Product> products = db.products;
        DbSet<Store> stores = db.stores;
        DbSet<Inventory> inventory = db.inventory;
        DbSet<OrderHistory> orderHistory = db.orderHistory;
        //DbSet<GuidToUserName> guidMapping = db.guids;
        public int LogIn(string userName)
        {
            while (true)
            {
                u1 = customers.Where(x => x.UserName == userName).FirstOrDefault();
                if (u1 == null) //it doesnt exist
                {
                    Console.WriteLine("The username you inputed either doesn't exist or is mispelled. Redirecting you back to main menu.");
                    return -1;
                }
                else
                {
                    //Console.WriteLine("Thanks for logging in!");
                    Console.WriteLine($"Welcome {u1.FName} {u1.LName} ({u1.UserName})!");

                    return 0;
                }
            }
        }
        public int CreateCustomer(string fName, string lName, string userName)
        {
            //Customer u1 = new Customer("null", "null", "null");
            while (true)
            {
                u1 = customers.Where(x => x.UserName == userName).FirstOrDefault();//x => x.FName == fName && x.LName == lName).FirstOrDefault();
                //Console.WriteLine($"{u1}");
                if (u1 == null)
                {
                    u1 = new Customer(fName, lName, userName);//, Guid.Parse(userId).ToString());
                    customers.Add(u1);
                    db.SaveChanges();
                    Console.WriteLine("WROTE TO SERVER\n");
                    Console.WriteLine($"Welcome {u1.FName} {u1.LName} ({u1.UserName})!");
                    return 0; //all set
                }
                else
                {
                    Console.WriteLine("Username is taken! Please try again.");
                    return -1;
                              //username is taken.
                              //ask for a new one
                }
            }
        }
        public void ShowInventory(int storeId)
        {
            Console.WriteLine("HERE");
            foreach(Inventory i in inventory)
            {
                if (i.StoreId == storeId)
                {
                    foreach(Product p in products)
                    {
                        if (p.ProductName == i.ProductName)
                        {
                            Console.WriteLine($"{i.ProductName} ({i.Quantity} in stock)\n\t{p.ProductDescription}\n");
                        }
                    }
                }
            }
        }
    }
}