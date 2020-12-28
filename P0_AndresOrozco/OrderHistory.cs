using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P0_AndresOrozco
{
    public class OrderHistory
    {
        private string userName;
        private Guid storeId;
        private long timestamp;
        private Guid productId;
        public OrderHistory(string userName, Guid storeId, long timestamp, Guid productId)
        {
            this.userName = userName;
            this.storeId = storeId;
            this.timestamp = timestamp;
            this.productId = productId;
        }

        [Key]
        public string UserName
        {
            get
            {
                return this.userName;
            }
            set
            {
                this.userName = value;
            }
        }
        public Guid StoreId
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

        public long Timestamp
        {
            get
            {
                return this.timestamp;
            }
            set
            {
                this.timestamp = value;
            }
        }
        public Guid ProductId
        {
            get
            {
                return this.productId;
            }
            set
            {
                this.productId = value;
            }
        }
    }
}