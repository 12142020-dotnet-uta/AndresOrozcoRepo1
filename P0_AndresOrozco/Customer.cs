using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace P0_AndresOrozco
{

    public class Customer
    {

        private string fName, lName, userName;
        private Guid userId;
        //private Guid userId;// = Guid.Empty;
        public Customer(string fName, string lName, string userName)//, string userId)
        {
            this.fName = fName;
            this.lName = lName;
            this.userName = userName;
            this.userId = Guid.NewGuid();//Parse(fName+lName);
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
        //[Key]
        public Guid CustomerId
        {
            get { return this.userId; }
            set
            {
                this.userId = Guid.NewGuid();
            }
        }
        [Key]
        public string UserName
        {
            get { return this.userName;}
            set
            {
                //check if unique first
                this.userName = value;
            }
        }
    }
}
