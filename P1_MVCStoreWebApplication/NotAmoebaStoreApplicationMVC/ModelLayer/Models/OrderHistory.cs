using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer
{
    public class OrderHistory
    {

        private Guid orderId, commonId;
        private int storeId; //will group by this when looking at history
        private string userName, productName;
        private double productPrice;//,totalOrder;
        private DateTime timestamp;
        private int productQuantity;

        public override string ToString()
        {
            return $"{orderId} | {commonId} | {storeId} | {userName} | {productName} | {productQuantity} | {timestamp}";
        }
        public OrderHistory(Guid orderId, Guid commonId, int storeId, string userName, string productName, int productQuantity, double productPrice, DateTime timestamp)
        {
            this.orderId = orderId;
            this.commonId = commonId;
            this.storeId = storeId;
            this.userName = userName;
            this.productName = productName;
            this.productQuantity = productQuantity;
            this.productPrice = productPrice;
            this.timestamp = timestamp;
        }
        [Key]
        public Guid OrderId
        {
            get { return this.orderId;}
            set { this.orderId = value;}
        }
        public Guid CommonId
        {
            get { return this.commonId;}
            set { this.commonId = value;}
        }
        public int StoreId
        {
            get { return this.storeId;}
            set { this.storeId = value;}
        }
        public string UserName
        {
            get { return this.userName;}
            set { this.userName = value;}
        }
        public string ProductName
        {
            get { return this.productName;}
            set { this.productName = value;}
        }

        public int ProductQuantity
        {
            get { return this.productQuantity;}
            set { this.productQuantity = value;}
        }
        public double ProductPrice //price of ONE SINGLE PRODUCT
        {
            get { return this.productPrice;}
            set { this.productPrice = value;}
        }
        public DateTime Timestamp
        {
            get {return this.timestamp;}
            set { this.timestamp = value;}
        }
    }
}
