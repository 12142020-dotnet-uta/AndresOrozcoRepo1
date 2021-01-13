using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ModelLayer.ViewModels
{
    public class InventoryViewModel
    {
        public InventoryViewModel()
        {

        }
        public InventoryViewModel(int storeId, string productName, int quantity)
        {
            Dictionary<int, string> storeMap = new Dictionary<int, string>()
            {
                {1, "Hollywood: NotAmoeba" },
                {2, "San Francisco: NotAmoeba" },
                {3, "Berkeley: Not Amoeba" }
            };
            this.StoreName = storeMap[storeId];
            this.ProductName = productName;
            this.Quantity = quantity;
        }
        [Display(Name="Store")]
        public string StoreName
        {
            get;set;
        }
        [Display(Name = "Product Name")]
        public string ProductName
        {
            get;set;
        }

        [Display(Name = "Quantity")]
        public int Quantity
        {
            get;set;
        }
    }
}
