using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.ViewModels
{
    public class ShopViewModel
    {
        public ShopViewModel()
        {

        }

        public ShopViewModel(int storeId, string storeName, string address)
        {
            this.StoreId = storeId;
            this.StoreName = storeName;
            this.Address = address;
        }

        public int StoreId
        {
            get;set;
        }
        public string StoreName
        {
            get;set;
        }

        public string Address
        {
            get;set;
        }



    }
}
