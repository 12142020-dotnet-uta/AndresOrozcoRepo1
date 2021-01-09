using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer
{
    public class Inventory
    {
        private Guid inventoryId;
        private string productName;
        private int storeId, quantity;

        public Inventory(Guid inventoryId, int storeId, string productName, int quantity)
        {
            this.inventoryId = inventoryId;
            this.storeId = storeId;
            this.productName = productName;
            this.quantity = quantity;
        }

        public Guid InventoryId
        {
            get
            {
                return this.inventoryId;
            }
            set
            {
                this.inventoryId = value;
            }
        }
        
        public int StoreId
        {
            get { return this.storeId;}
            set { this.storeId = value;}
        }
        //[Key]
        public string ProductName
        {
            get { return this.productName;}
            set { this.productName = value;}
        }
        public int Quantity
        {
            get { return this.quantity; }
            set { this.quantity = value; }
        }
    }
}