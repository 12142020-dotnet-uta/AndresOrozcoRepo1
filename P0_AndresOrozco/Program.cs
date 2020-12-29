using System;
using System.Collections.Generic;

namespace P0_AndresOrozco
{
    class Program
    {
        //static StoreAppRepositoryLayer storeContext = new StoreAppRepositoryLayer();
        //public StoreAppRepositoryLayer storeContext = new StoreAppRepositoryLayer();
        public static int store;
        public static void Main(string[] args)
        {
            Control c = new Control();
            StoreAppDBContext dbContext = new StoreAppDBContext();
            StoreAppRepositoryLayer storeContext = new StoreAppRepositoryLayer(dbContext);
            //Validation validate = new Validation();

            while(true)
            {

                c.MenuSplash();
                (int option, string userName) = c.GetOption();
                if (option == -1 ) //general error
                {
                    continue;
                }
                if (option == 3) break;
                if (option == 0) //good
                {
                    //SAVE LOCAL LIST HERE OF ALL ORDERED PRODUCTS
                    //int status = c.ChooseStore();
                    while(true)
                    {
                        //originally here
                        int status = c.ChooseStore();
                        //
                        if (status == -1 || status == 0) break;
                        else
                        {
                            Dictionary<string, int> currentOrder = new Dictionary<string, int>();
                            while (true)
                            {
                                storeContext.ShowInventory(status, currentOrder);
                                store = status; //store the storeID locally for now

                                (string productName, int quantity) = c.ChooseProduct();

                                if (productName == "quit") break; //change of store, drop everthing
                                else if (productName == "checkout")
                                {
                                    List<OrderHistory> oh = storeContext.AddToCart(userName, store,currentOrder);
                                    storeContext.AddToOrderHistory(oh);
                                    currentOrder.Clear(); //we dont need this anymore!
                                    break;
                                }
                                else //still deciding
                                {
                                    //append to local orders
                                    if (currentOrder.ContainsKey(productName))
                                    {
                                        currentOrder[productName]++; //adding to existing product
                                    }
                                    else
                                    {
                                        currentOrder.Add(productName, quantity); //adding new product with its quantity
                                    }
                                }
                            }
                        }
                    }
                    //break; //will take out
                }
            }
        }
    }
}
