using System;
namespace P0_AndresOrozco
{

    public class User
    {

        private string fName, lName;


        public User(string fName, string lName)
        {
            this.fName = fName;
            this.lName = lName;
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
    }
}
