using System;

namespace P0_AndresOrozco
{
    class Program
    {

        //static StoreAppRepositoryLayer gameContext = new StoreAppRepositoryLayer();
        static StoreAppRepositoryLayer gameContext = new StoreAppRepositoryLayer();
        public static void Main(string[] args)
        {
            Validation validate = new Validation();
            while(true)
            {
                Console.WriteLine("Welcome to the Store Application!\n\tPlease choose an option:\n\t\t1. Log In\n\t\t2. Create Account\n\t\t3. Quit Program");
                string option = Console.ReadLine();
                int value = validate.VerifyOptions(option);
                if (value == 1) //log in
                {
                    Console.WriteLine("What is your username?");
                    string userName = Console.ReadLine();
                    //method doesnt exist yet for me
                    //checkCustomername(userName);
                }
                else if (value == 2) //create account
                {
                    string fName, lName, userName;//, userId;
                    Console.Write("First Name: ");
                    fName = Console.ReadLine();
                    Console.Write("Last Name: ");
                    lName = Console.ReadLine();
                    Console.Write("Username: ");
                    userName = Console.ReadLine();
                    Customer u = gameContext.CreateCustomer(fName, lName, userName);//,userId);

                    
                }
                else if (value == 3) break; //quit
                else
                {
                }
            }
            //Customer u = gameContext.CreateCustomer("Xiana" , "Posada");
            //Console.WriteLine($"Created the user,{u.FName} {u.LName}");
        }
    }
}
