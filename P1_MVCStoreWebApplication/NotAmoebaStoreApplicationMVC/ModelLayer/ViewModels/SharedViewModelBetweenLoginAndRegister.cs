using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.ViewModels
{
    public class SharedViewModelBetweenLoginAndRegister
    {
        public SharedViewModelBetweenLoginAndRegister()
        {

        }
        public SharedViewModelBetweenLoginAndRegister(string fname, string lname, string username, string store)
        {
            this.FName = fname;
            this.LName = lname;
            this.UserName = username;
            this.Store = store;
        }

        [StringLength(10, ErrorMessage = "The last name must be from 3 to 10 characters.", MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [Required]
        [Display(Name = "First Name")]
        public string FName { get; set; }

        [StringLength(10, ErrorMessage = "The last name must be from 3 to 10 characters.", MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [Required]
        [Display(Name = "Last Name")]
        public string LName { get; set; }


        [StringLength(10, ErrorMessage = "The username must be from 4 to 10 characters.", MinimumLength = 3)]
        [RegularExpression(@"^[\w]+$", ErrorMessage = "Letters, numbers, and underscores only.")]
        [Required]
        [Display(Name = "Username")]
        //[Key]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Choose a default store location")] //they can change in EDIT login
        public string Store { get; set; }


    }
}
