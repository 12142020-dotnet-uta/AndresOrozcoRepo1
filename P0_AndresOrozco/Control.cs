using System;
namespace P0_AndresOrozco
{
    public class Control
    {
        StoreAppRepositoryLayer gameContext = new StoreAppRepositoryLayer();

        public void MenuSplash()
        {
            Console.WriteLine("Welcome to NotAmoeba!\n\tPlease choose an option:\n\t\t1. Log In\n\t\t2. Create Account\n\t\t3. Quit Program");
        }
        public int GetOption()
        {

            string option = Console.ReadLine();
            //int value = VerifyOptions(option);
            if (option == "1") //log in
            {
                Console.Write("What is your username: ");
                string userName = Console.ReadLine();
                int statusCode = gameContext.LogIn(userName);
                return statusCode;
                //method doesnt exist yet for me
                //checkCustomername(userName);
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
                int statusCode = gameContext.CreateCustomer(fName, lName, userName);//,userId);
                return statusCode;

            }
            else if (option == "3")
            {
                Console.WriteLine("Thanks for choosing NotAmoeba!");
                return 3;
            } //quit
            else
            {
                Console.WriteLine("Please input something valid!");
                return -1;
            }
        }
        public int ChooseStore()
        {
            Console.WriteLine("Please choose which location you would like to shop at below!");
            Console.WriteLine("\t 1. Hollywood, CA \n\t 2. Berkeley, CA \n\t 3. San Francisco, CA");
            string store = Console.ReadLine();
            if (store == "1" || store == "2" || store == "3")
            {
                int storeId = Int32.Parse(store);
                Console.WriteLine(store);
                return 1;
            }
            else
            {
                return -1;
            }
            //return -1;
        }
    }
}