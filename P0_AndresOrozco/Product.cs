
using System.ComponentModel.DataAnnotations;

namespace P0_AndresOrozco
{
    public class Product
    {
        public Product(int productId, string productName, double productPrice, string productDescription)
        {
            this.productId = productId;
            this.productName = productName;
            this.productPrice = productPrice;
            this.productDescription = productDescription;
        }

        private int productId;
        private string productName;
        private double productPrice;
        private string productDescription;

        [Key]
        public int ProductId
        {
            get { return this.productId; }
            set { this.productId = value; }
        }

        public string ProductName
        {
            get {return this.productName;}
            set { this.productName = value;}
        }

        public double ProductPrice
        {
            get { return this.productPrice;}
            set { this.productPrice = value;}
        } 

        public string ProductDescription
        {
            get { return this.productDescription;}
            set { this.productDescription = value;}
        }
    }
}