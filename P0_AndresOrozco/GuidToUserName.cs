using System;
using System.ComponentModel.DataAnnotations;
namespace P0_AndresOrozco
{
    public class GuidToUserName
    {
        private string userName;
        private Guid customerId;
        public GuidToUserName(Guid customerId, string userName)
        {
            this.customerId = customerId;
            this.userName = userName;
        }
        public string UserName
        {
            get { return this.userName; }
            set { this.userName = value; }
        }
        [Key]
        public Guid CustomerId
        {
            get {return this.customerId;}
            set { this.customerId = value;}
        }
    }
}