using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P0_AndresOrozco
{
    public class Inventory
    {
        private string productName;
        private int storeId, quantity;

        public Inventory(int storeId, string productName, int quantity)
        {
            this.storeId = storeId;
            this.productName = productName;
            this.quantity = quantity;
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