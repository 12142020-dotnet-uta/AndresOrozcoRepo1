using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

Dictionary<int, string> storeMap = new Dictionary<int, string>()
{
    {1, "Hollywood: NotAmoeba" },
    {2, "San Francisco: NotAmoeba" },
    {3, "Berkeley: Not Amoeba" }
};

namespace ModelLayer.ViewModels
{
    public class InventoryViewModel
    {
        public InventoryViewModel()
        {

        }
        public InventoryViewModel(int storeId, string productName, int quantity)
        {
            this.storeId = storeId;
            this.productName = productName;
            this.quantity = quantity;
        }
    }
}
