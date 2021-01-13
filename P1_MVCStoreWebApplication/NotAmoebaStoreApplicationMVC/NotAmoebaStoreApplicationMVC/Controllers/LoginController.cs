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
            //return View("DisplayCustomerDetails", customerViewModel);
            if (customerViewModel != null)
            {
                return View("DisplayCustomerDetails", customerViewModel);
            }
            else
            {
                ModelState.AddModelError("Failure", "Did not find that username. Redirected you to register");
                //System.Threading.Thread.Sleep(2000);
                return View("../Register/Register");
                //return View("Register");
            }
        }

        [ActionName("Register")]
        public IActionResult Register(LoginCustomerViewModel loginCustomerViewModel)
        {
            if (loginCustomerViewModel.UserName == null)
            {
                return View();
            }

            CustomerViewModel customerViewModel = _businessLogicClass.RegisterCustomer(loginCustomerViewModel);
            return View("DisplayCustomerDetails", customerViewModel);
        }
        //public IActionResult Register()
        //{
        //    return View();
        //}

    }
}
