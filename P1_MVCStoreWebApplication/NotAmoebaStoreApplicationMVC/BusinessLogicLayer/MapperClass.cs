using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using ModelLayer.ViewModels;

namespace BusinessLogicLayer
{
    public class MapperClass
    {
        public CustomerViewModel ConvertCustomerToCustomerViewModel(Customer c)
        {
            CustomerViewModel cViewModel = new CustomerViewModel(c.FName, c.LName, c.UserName);
            return cViewModel;
        }
    }
}
