using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P0_AndresOrozco
{
    public class OrderHistory
    {
        private Guid orderId;
        private int storeId; //will group by this when looking at history
        private string userName, productName;
        private double productPrice, totalOrder;
        private DateTime timestamp;
        public OrderHistory(Guid orderId, int storeId, string userName, string productName, double productPrice, double totalOrder, DateTime timestamp)
        {
            this.orderId = orderId;
            this.storeId = storeId;
            this.userName = userName;
            this.productName = productName;
            this.productPrice = productPrice;
            this.totalOrder = totalOrder;
            this.timestamp = timestamp;
        }
        [Key]
        public Guid OrderId
        {
            get { return this.orderId;}
            set { this.orderId = value;}
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
        public double ProductPrice
        {
            get { return this.productPrice;}
            set { this.productPrice = value;}
        }
        public double TotalOrder
        {
            get {return this.totalOrder;}
            set { this.totalOrder = value;}
        }
        public DateTime Timestamp
        {
            get {return this.timestamp;}
            set { this.timestamp = value;}
        }
    }
}