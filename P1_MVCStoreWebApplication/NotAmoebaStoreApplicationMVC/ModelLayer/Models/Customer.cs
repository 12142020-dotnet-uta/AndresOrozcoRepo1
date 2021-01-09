using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer
{

    public class Customer
    {

        private string fName, lName, userName, store;

        public Customer()
        {
        }

        public Customer(string fName, string lName, string userName, string store)//, string userId)
        {
            this.userName = userName;
            this.fName = fName;
            this.lName = lName;
            this.store = store;
        }
        //Properties Below
        [StringLength(10, ErrorMessage = "The last name must be from 3 to 10 characters.", MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [Required]
        [Display(Name = "First Name")]
        public string FName
        {
            get { return fName;}
            set { this.fName = value; }
            //{
            //    if (value is string && value.Length < 20)
            //    {
            //        this.fName = value;
            //    }
            //    else
            //    {
            //        throw new Exception("First name is invalid");
            //    }
            //}
        }
        [StringLength(10, ErrorMessage = "The last name must be from 3 to 10 characters.", MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [Required]
        [Display(Name = "Last Name")]
        public string LName
        {
            get { return lName;}
            set { this.lName = value; }
            //set
            //{
            //    if (value is string && value.Length < 20)
            //    {
            //        this.lName = value;
            //    }
            //    else
            //    {
            //        throw new Exception("Last name is invalid");
            //    }
            //}
        }
        [StringLength(10, ErrorMessage = "The username must be from 4 to 10 characters.", MinimumLength = 3)]
        [RegularExpression(@"^[\w]+$", ErrorMessage = "Letters, numbers, and underscores only.")]
        [Required]
        [Display(Name = "Username")]
        [Key]
        public string UserName
        {
            get { return this.userName; }
            set { this.userName = value; }
        }


        [Display(Name = "Choose Your Store Location")]
        [Required]
        public string Store
        {
            get { return this.store; }
            set { this.store = value; }
        }

        //public static explicit operator bool(Customer v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
