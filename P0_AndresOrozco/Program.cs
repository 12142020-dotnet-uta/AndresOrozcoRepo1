using System;

namespace P0_AndresOrozco
{
    class Program
    {
        static void Main(string[] args)
        {
            User me = new User("Andres", "Orozco");
            Console.WriteLine($"Created the user, {me.FName} {me.LName}");
            /*
            while(true)
            {
                //logging in
                while (true)
                {
                    //checking stores
                    while (true)
                    {
                        //idk
                    }
                }

            }
            */
            Console.WriteLine("Hello World!");
        }
    }
}
