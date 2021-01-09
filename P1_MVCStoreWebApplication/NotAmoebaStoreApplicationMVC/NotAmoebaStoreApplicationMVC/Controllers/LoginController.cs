using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using ModelLayer.ViewModels;
using Microsoft.AspNetCore.Http;


namespace NotAmoebaStoreApplicationMVC.Controllers
{
    public class LoginController : Controller
    {
        private BusinessLogicClass _businessLogicClass;

        public LoginController(BusinessLogicClass businessLogicClass)
        {
            _businessLogicClass = businessLogicClass;
        }

        //[ActionName("LogIn")]
        public IActionResult Login()
        {
            return View();
        }

        
        [ActionName("LoginCustomer")]
        public IActionResult Login(LoginCustomerViewModel loginCustomerViewModel)
        {
            //Customer c = new Customer(fName: loginCustomerViewModel.FName, lName: loginCustomerViewModel.LName, userName: loginCustomerViewModel.UserName);
            //things to do to log in...
            //use DI (dependency injection!) to get instance of customer class
            //and access to its functionality


            //LoginCustomerViewModel loginCustomerViewModel = _businessLogicCLass.LoginCustomer();
            //return View("DisplayCustomerDetails");//, c);

            CustomerViewModel customerViewModel = _businessLogicClass.LoginCustomer(loginCustomerViewModel);
            return View("DisplayCustomerDetails", customerViewModel);
            //if (customerViewModel != null)
            //{
            //    return View("DisplayCustomerDetails", customerViewModel);
            //}
            //else
            //{
            //    return View("Register");
            //}

        }
        
    }
}
