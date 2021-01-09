namespace ModelLayer
{
    public class Store
    {
        private int storeId;
        private string storeName, address;

        public Store(int storeId, string storeName, string address)
        {
            this.storeId= storeId;
            this.storeName = storeName;
            this.address = address;
        }

        public int StoreId
        {
            get
            {
                return this.storeId;
            }
            set
            {
                this.storeId = value;
            }
        }
        public string StoreName
        {
            get
            {
                return this.storeName;
            }
            set
            {
                this.storeName = value;
            }
        }
        public string Address
        {
            get
            {
                return this.address;
            }
            set
            {
                this.address = value;
            }
        }

    }
}