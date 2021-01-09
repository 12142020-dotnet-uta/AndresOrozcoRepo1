using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.ViewModels
{
    public class LoginCustomerViewModel
    {

        [StringLength(10, ErrorMessage = "The last name must be from 3 to 10 characters.", MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [Required]
        [Display(Name = "First Name")]
        public string FName {get; set;}

        [StringLength(10, ErrorMessage = "The last name must be from 3 to 10 characters.", MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [Required]
        [Display(Name = "Last Name")]
        public string LName { get; set; }


        [StringLength(10, ErrorMessage = "The username must be from 4 to 10 characters.", MinimumLength = 3)]
        [RegularExpression(@"^[\w]+$", ErrorMessage = "Letters, numbers, and underscores only.")]
        [Required]
        [Display(Name = "Username")]
        [Key]
        public string UserName { set; get; }


    }
}
