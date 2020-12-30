using System;
namespace P0_AndresOrozco
{
    public class Control
    {
        /// <summary>
        /// Gives initial menu header to allow the user to choose who he/she wants to do.
        /// </summary>
        public void MenuSplash()
        {
            Console.WriteLine("Welcome to NotAmoeba!\n\tPlease choose an option:\n\t\t1. Log In\n\t\t2. Create Account\n\t\t3. View Order History\n\t\t4. Quit Program");
        }
        /// <summary>
        /// Handles input from the inital menu header to see where the user wants to navigate to. 
        /// </summary>
        /// <param name="GetOption("></param>
        /// <returns>(int statusCode, string userName)</returns>
        public (int,string) GetOption()
        {
            StoreAppDBContext dbContext = new StoreAppDBContext();
            StoreAppRepositoryLayer storeContext = new StoreAppRepositoryLayer(dbContext);
            string option = Console.ReadLine();
            //int value = VerifyOptions(option);
            if (option == "1") //log in
            {
                Console.Write("What is your username: ");
                string userName = Console.ReadLine();
                int statusCode = storeContext.LogIn(userName);
                return (statusCode,userName);
            }
            else if (option == "2") //create account
            {
                string fName, lName, userName;//, userId;
                //needs to be all lowercase and letters only for
                //all entries
                Console.Write("First Name: ");
                fName = Console.ReadLine();
                Console.Write("Last Name: ");
                lName = Console.ReadLine();
                Console.Write("Username: ");
                userName = Console.ReadLine();
                int statusCode = storeContext.CreateCustomer(fName, lName, userName);//,userId);
                return (statusCode,userName);

            }
            else if (option == "3") //looking up order history
            {
                Console.Write("Please enter the username: ");
                string userName = Console.ReadLine();
                Console.WriteLine("\t 1. Hollywood, CA \n\t 2. Berkeley, CA \n\t 3. San Francisco, CA\n\t 4. All Stores");
                Console.Write("What store ID: ");
                string storeId = Console.ReadLine();
                return (3, userName+'_'+storeId);
            }
            else if (option == "4") //quit
            {
                Console.WriteLine("Thanks for choosing NotAmoeba!");
                return (4,null);
            }
            else
            {
                Console.WriteLine("Please input something valid!");
                return (-1, null);
            }
        }

        /// <summary>
        ///  After signing in/creating an account, this allows the user to pick the store they want to shop at, or they can simply log out.
        /// </summary>
        /// <returns>int storeId</returns>
        public int ChooseStore()
        {
            //StoreAppDBContext dbContext = new StoreAppDBContext();
            //StoreAppRepositoryLayer storeContext = new StoreAppRepositoryLayer(dbContext);

            Console.WriteLine("Please choose which location you would like to shop at below!");
            Console.WriteLine("\t 1. Hollywood, CA \n\t 2. Berkeley, CA \n\t 3. San Francisco, CA\n\tor\n\t4. Log out");
            string store = Console.ReadLine();
            if (store == "1" || store == "2" || store == "3")
            {
                return Int32.Parse(store);
            }
            else if (store == "4")
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ChooseProduct("></param>
        /// <returns></returns>
        public (string,int) ChooseProduct()
        {
            StoreAppDBContext dbContext = new StoreAppDBContext();
            StoreAppRepositoryLayer storeContext = new StoreAppRepositoryLayer(dbContext);
            while(true)
            {
                Console.Write("Please type in the product name (or 'checkout' or 'quit'): ");//\n\tNOTICE:\n\t\t1. Typing 'quit' will log you out and nothing will be check out\n\t\t2. Typing 'checkout' will display your cart."); //permanently charge your account and the items will ship soon.");
                string productName = Console.ReadLine();
                if (productName == "quit")
                {
                    return (productName, -1);
                }
                else if (productName == "checkout")
                {
                    return (productName, 0);
                }

                int status = storeContext.CheckProduct(productName);

                if (status == -1)
                {
                    Console.WriteLine("Could not find that product. Please try again.");
                }

                else
                {
                    Console.Write("How many: ");
                    int quantityDesired = Int32.Parse(Console.ReadLine());
                    return (productName, quantityDesired);
                }
            }
        }

    }
}