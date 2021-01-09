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

        public StoreAppRepositoryLayer() {}
        public StoreAppRepositoryLayer(StoreAppDBContext context)
        {
            this.db = context;
            this.customers = db.customers;
            this.products = db.products;
            this.stores = db.stores;
            this.inventory = db.inventory;
            this.orderHistory = db.orderHistory;
        }


        /// <summary>
        /// Will look through customer DB to check if the given username exists.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>0 if able to log in, -1 otherwise</returns>
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

        
        /// <summary>
        /// Given a first, last, and username, if the username is unique, it will
        /// create a new entry; else it will send you back to main menu after error message.
        /// </summary>
        /// <param name="fName"></param>
        /// <param name="lName"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
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
                    Console.WriteLine($"Welcome {c1.FName} {c1.LName} ({c1.UserName})!");
                    return 0; //all good
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

        /// <summary>
        /// Given the storeId and the current Dictionary<productName,Quantity>
        /// it will simulate quantity subtracting just in case 
        /// user decides to leave abruptly.
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="currentOrder"></param>
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
        

        /// <summary>
        /// WIll check if the inputted product exists in the DB.
        /// </summary>
        /// <param name="productName"></param>
        /// <returns>-1 if non existent, 0 otherwise</returns>

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
                }
            }
        }
        
        /// <summary>
        /// Will finalize the current order by writing to DB. Will also calculate the product price times quantity and
        /// will sum the total at the end.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="storeId"></param>
        /// <param name="currentOrder"></param>
        public void CheckoutCart(string userName, int storeId, Dictionary<string,int> currentOrder)
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
                                orderHistory.Add(order);
                            }
                        }
                    }
                }
            }
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"TOTAL: {Math.Round(totalOrder,2)}");
            db.SaveChanges();//UNCOMMENT ON PRODUCTION
        }
        

        /// <summary>
        ///  Given the username and storeId, it will search through all of their
        /// previous orders and print to the console. Can retreive orders from all stores, if needed.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="storeId"></param>         
        public void GetOrderHistory(string userName, int storeId)
        {

            int inside = 0;
            double total = 0;
            string storeName = "null";
            if (storeId > 0 && storeId < 4)
            {
                foreach (Store s in stores)
                {
                    if (s.StoreId == storeId)
                    {
                        storeName = s.StoreName;
                    }
                }
                Console.WriteLine($"Order History For: {userName} at {storeName}");
                foreach (OrderHistory o in orderHistory)
                {
                    if (o.UserName == userName && o.StoreId == storeId)
                    {
                        total += (o.ProductPrice * o.ProductQuantity);
                        Console.WriteLine($"{o.ProductName} ({o.ProductPrice}) x {o.ProductQuantity}--------{o.ProductPrice * o.ProductQuantity}");
                        inside++;
                    }
                }
                if (inside == 0)
                {
                    Console.WriteLine("Found no order history!");
                    return;
                }
                else
                {
                    Console.WriteLine("------------------------");
                    Console.WriteLine($"Total was = ${Math.Round(total,2)}");
                }
            }
            else if (storeId == 4)
            {

                foreach (Store s in stores)
                {
                    storeName = s.StoreName;
                    Console.WriteLine($"Order History For: {userName} at {storeName}");
                    foreach (OrderHistory o in orderHistory)
                    {
                        if (o.UserName == userName && o.StoreId == s.StoreId)
                        {
                            total += (o.ProductPrice * o.ProductQuantity);
                            Console.WriteLine($"{o.ProductName} ({o.ProductPrice}) x {o.ProductQuantity}--------{o.ProductPrice * o.ProductQuantity}");
                            inside++;
                        }
                    }
                    if (inside == 0) //no order history
                    {
                        Console.WriteLine("Found no order history!");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("------------------------");
                        Console.WriteLine($"Total was = ${Math.Round(total,2)}");
                        total = 0;
                    }
                }
            }
        }
    }
}
