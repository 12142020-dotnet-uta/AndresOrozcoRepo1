using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace P0_AndresOrozco
{

    public class Customer
    {

        private string fName, lName, userName;
        //private Guid customerId;
        //private Guid userId;// = Guid.Empty;
        public Customer(string fName, string lName, string userName)//, string userId)
        {
            this.userName = userName;
            this.fName = fName;
            this.lName = lName;
            //this.customerId = Guid.NewGuid();
        }

        //Properties Below
        public string FName
        {
            get { return fName;}
            set
            {
                if (value is string && value.Length < 20)
                {
                    this.fName = value;
                }
                else
                {
                    throw new Exception("First name is invalid");
                }
            }
        }
        public string LName
        {
            get { return lName;}
            set
            {
                if (value is string && value.Length < 20)
                {
                    this.lName = value;
                }
                else
                {
                    throw new Exception("Last name is invalid");
                }
            }
        }
        /*
        [Key]
        public Guid CustomerId
        {
            get { return this.customerId; }
            //set { this.customerId = Guid.NewGuid();}
        }
        */
        
        [Key]
        public string UserName
        {
            get { return this.userName;}
            set
            {
                this.userName = value;
            }
        }
    }
}
