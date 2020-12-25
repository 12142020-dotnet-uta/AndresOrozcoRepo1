using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P0_AndresOrozco
{
    public class Inventory
    {
        public Inventory(int storeId, int productId, int quantity)
        {
            this.storeId = storeId;
            this.productId = productId;
            this.quantity = quantity;
        }
        private int storeId, productId, quantity;

        //[Key]
        public int StoreId
        {
            get { return this.storeId;}
            set { this.storeId = value;}
        }
        //[Key]
        public int ProductId
        {
            get { return this.productId;}
            set { this.productId = value;}

        }
        public int Quantity
        {
            get { return this.quantity; }
            set { this.quantity = value; }
        }
        
    }
}