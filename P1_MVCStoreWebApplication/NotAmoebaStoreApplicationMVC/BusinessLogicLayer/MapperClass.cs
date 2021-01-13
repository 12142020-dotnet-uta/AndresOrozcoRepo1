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
            if (c == null) return null;
            CustomerViewModel cViewModel = new CustomerViewModel(c.FName, c.LName, c.UserName, c.Store);
            return cViewModel;
        }

        public InventoryViewModel ConvertInventoryToInventoryModel(Inventory i)
        {
            if (i == null) return null;
            InventoryViewModel iViewModel = new InventoryViewModel(i.StoreId, i.ProductName, i.Quantity);
            return iViewModel;
        }

    }
}
