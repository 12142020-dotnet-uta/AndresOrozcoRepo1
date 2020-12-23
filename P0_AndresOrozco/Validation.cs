using System;
namespace P0_AndresOrozco
{
    public class Validation
    {
        /// <summary>
        /// Verifies whether the user wants to: log in, create an account, or quit the program.
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        public int VerifyOptions(string option)
        {
            if (option.Equals("1")) //Log In
            {
                return 1;

            }
            else if (option.Equals("2")) //Create Account
            {
                return 2;

            }
            else if (option.Equals("3")) //Quit
            {
                Console.WriteLine("Thank you for choosing this Store Application! Goodbye.");
                return 3;
            }
            else //invalid reponse
            {
                Console.WriteLine("Please enter a valid response");
                return -1;
            }

        }
        public bool VerifyUsername(string fName, string lName, string username)
        {

            return true;
        }
        
    }
}