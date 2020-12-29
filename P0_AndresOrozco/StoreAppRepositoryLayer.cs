using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

namespace P0_AndresOrozco
{
    public class StoreAppRepositoryLayer
    {
        public Customer c1 = new Customer("null", "null", "null");
        public Inventory i1 = new Inventory(Guid.NewGuid(), -1, "null", -1);
        StoreAppDBContext db;
        DbSet<Customer> customers;
        DbSet<Product> products;
        DbSet<Store> stores;
        DbSet<Inventory> inventory;
        DbSet<OrderHistory> orderHistory;

        public StoreAppRepositoryLayer(StoreAppDBContext context)
        {
            this.db = context;
            this.customers = db.customers;
            this.products = db.products;
            this.stores = db.stores;
            this.inventory = db.inventory;
            this.orderHistory = db.orderHistory;
        }
        /*
        static StoreAppDBContext db = new StoreAppDBContext();
        //DbSet<Customer> users = StoreAppDBContext.users;
        DbSet<Customer> customers = db.customers;
        DbSet<Product> products = db.products;
        DbSet<Store> stores = db.stores;
        DbSet<Inventory> inventory = db.inventory;
        DbSet<OrderHistory> orderHistory = db.orderHistory;
        //DbSet<GuidToUserName> guidMapping = db.guids;
        */
        public int LogIn(string userName)
        {
            while (true)
            {
                c1 = customers.Where(x => x.UserName == userName).FirstOrDefault();
                if (c1 == null) //it doesnt exist
                {
                    Console.WriteLine("The username you inputed either doesn't exist or is mispelled. Redirecting you back to main menu.");
                    return -1;
                }
                else
                {
                    //Console.WriteLine("Thanks for logging in!");
                    Console.WriteLine($"Welcome {c1.FName} {c1.LName} ({c1.UserName})!");

                    return 0;
                }
            }
        }
        public int CreateCustomer(string fName, string lName, string userName)
        {
            //Customer c1 = new Customer("null", "null", "null");
            while (true)
            {
                c1 = customers.Where(x => x.UserName == userName).FirstOrDefault();//x => x.FName == fName && x.LName == lName).FirstOrDefault();
                //Console.WriteLine($"{c1}");
                if (c1 == null)
                {
                    c1 = new Customer(fName, lName, userName);//, Guid.Parse(userId).ToString());
                    customers.Add(c1);
                    db.SaveChanges();
                    Console.WriteLine("WROTE TO SERVER\n");
                    Console.WriteLine($"Welcome {c1.FName} {c1.LName} ({c1.UserName})!");
                    return 0;
                }
                else
                {
                    Console.WriteLine("Username is taken! Please try again.");
                    return -1;//(-1, c1.UserName);
                              //username is taken.
                              //ask for a new one
                }
            }
        }
        public void ShowInventory(int storeId, Dictionary<string,int> currentOrder)
        {
            foreach(Inventory i in inventory)
            {
                if (i.StoreId == storeId)
                {
                    foreach(Product p in products)
                    {
                        if (p.ProductName == i.ProductName)
                        {
                            if (currentOrder.Count != 0)
                            {
                                foreach (var item in currentOrder)
                                {
                                    if (item.Key == i.ProductName)
                                    {
                                        if (i.Quantity > 0) Console.WriteLine($"{i.ProductName} ${p.ProductPrice} ({i.Quantity - item.Value} in stock)\n\t{p.ProductDescription}\n");
                                        else Console.WriteLine($"{i.ProductName} ${p.ProductPrice} (OUT OF STOCK!)\n\t{p.ProductDescription}\n");
                                    }
                                    else
                                    {
                                        if (i.Quantity > 0) Console.WriteLine($"{i.ProductName} ${p.ProductPrice} ({i.Quantity} in stock)\n\t{p.ProductDescription}\n");
                                        else Console.WriteLine($"{i.ProductName} ${p.ProductPrice} (OUT OF STOCK!)\n\t{p.ProductDescription}\n");
                                    }
                                }
                            }
                            else
                            {
                                if (i.Quantity > 0) Console.WriteLine($"{i.ProductName} ${p.ProductPrice} ({i.Quantity} in stock)\n\t{p.ProductDescription}\n");
                                else Console.WriteLine($"{i.ProductName} ${p.ProductPrice} (OUT OF STOCK!)\n\t{p.ProductDescription}\n");
                            }
                        }
                    }
                }
            }
        }
        public int CheckProduct(string productName)
        {
            while (true)
            {
                i1 = inventory.Where(x=>x.ProductName == productName).FirstOrDefault();
                if (i1 == null) //doesn't exist
                {
                    return -1;
                }
                else //exists
                {
                    return 0;
                    //i1.Quantity--; //decrement
                }
            }
        }
        

        public List<OrderHistory> AddToCart(string userName, int storeId, Dictionary<string,int> currentOrder)
        {
            double productTotal = 0.0;
            double totalOrder = 0;
            List<OrderHistory> oh = new List<OrderHistory>();
            DateTime timestamp = DateTime.UtcNow;
            Guid commonId = Guid.NewGuid();
            //double productPrice;
            OrderHistory order;
            foreach(var item in currentOrder) //item is (key: productName, value: quantity)
            {
                string productName = item.Key;
                int productQuantity = item.Value;
                i1 = inventory.Where(x => x.ProductName == productName).FirstOrDefault();
                foreach(Inventory i in inventory)
                {
                    if (i.ProductName == productName)
                    {
                        foreach (Product p in products)
                        {
                            if (p.ProductName == i.ProductName)
                            {
                                productTotal = (p.ProductPrice * productQuantity);
                                //can print out cart
                                Console.WriteLine($"{productName} x {productQuantity} = {productTotal}");
                                //it has been found, we decrement quantity and return totalOrder price
                                i1.Quantity -= productQuantity;
                                totalOrder += productTotal;
                                order = new OrderHistory(Guid.NewGuid(), commonId, storeId, userName, productName, productQuantity, p.ProductPrice, timestamp);
                                oh.Add(order);
                            }
                        }

                        //OrderHistory order = new OrderHistory(Guid.NewGuid(), commonId, storeId, userName, productName, productQuantity, p.ProductPrice, timestamp);
                    }
                }
            }
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"TOTAL: {Math.Round(totalOrder,2)}");
            db.SaveChanges();//UNCOMMENT ON PRODUCTION
            return oh;
        }
        public void AddToOrderHistory(List<OrderHistory> oh)
        {
            foreach(OrderHistory o in oh)
            {
                Console.WriteLine(o);
                orderHistory.Add(o);
            }
            db.SaveChanges();
        }
    }
}
