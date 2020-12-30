using System;
using System.Collections.Generic;

namespace P0_AndresOrozco
{
    class Program
    {
        public static void Main(string[] args)
        {
            Control c = new Control();
            StoreAppDBContext dbContext = new StoreAppDBContext();
            StoreAppRepositoryLayer storeContext = new StoreAppRepositoryLayer(dbContext);
            int storeId;

            while(true)
            {

                c.MenuSplash();
                (int option, string userName) = c.GetOption();
                if (option == -1 ) //general error
                {
                    continue;
                }
                else if (option == 3) //getting order history
                {
                    string[] response = userName.Split('_');
                    userName = response[0];
                    storeId = Int32.Parse(response[1]);
                    storeContext.GetOrderHistory(userName,storeId);
                }
                else if (option == 4) break; //quitting
                if (option == 0) //good
                {
                    //SAVE LOCAL LIST HERE OF ALL ORDERED PRODUCTS
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
                                storeId = status; //store the storeID locally for now

                                (string productName, int quantity) = c.ChooseProduct();

                                if (productName == "quit") break; //change of store, drop everthing
                                else if (productName == "checkout")
                                {
                                    storeContext.CheckoutCart(userName,storeId,currentOrder);
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
                }
            }
        }
    }
}
