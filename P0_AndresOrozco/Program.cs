using System;

namespace P0_AndresOrozco
{
    class Program
    {
        static StoreAppRepositoryLayer storeContext = new StoreAppRepositoryLayer();
        public static int store;
        public static void Main(string[] args)
        {
            Control c = new Control();
            //Validation validate = new Validation();

            while(true)
            {
                c.MenuSplash();
                int option = c.GetOption();
                if (option == -1 ) //general error
                {
                    continue;
                }
                if (option == 3) break;
                if (option == 0) //good
                {
                    while(true)
                    {
                        int status = c.ChooseStore();
                        if (status == -1) break;
                        else
                        {
                            storeContext.ShowInventory(status);
                            //store = status; //store the storeID locally for now
                        }
                    }
                    break;

                }
            }
        }
    }
}
