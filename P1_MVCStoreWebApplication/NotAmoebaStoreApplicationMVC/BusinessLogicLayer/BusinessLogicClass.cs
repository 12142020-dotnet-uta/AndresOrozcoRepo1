using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using ModelLayer.ViewModels;
using RepositoryLayer;

namespace BusinessLogicLayer
{
    public class BusinessLogicClass
    {
        private readonly Repository _repository;
        private readonly MapperClass _mapperClass;
        public BusinessLogicClass(Repository repository, MapperClass mapperClass)
        {
            _repository = repository;
            _mapperClass = mapperClass;
        }
        public CustomerViewModel LoginCustomer(LoginCustomerViewModel loginCustomerViewModel)
        {

            Customer c = new Customer()
            {
                FName = loginCustomerViewModel.FName,
                LName = loginCustomerViewModel.LName,
                UserName = loginCustomerViewModel.UserName
            };

            Customer c1 = _repository.LoginCustomer(c);

            CustomerViewModel customerViewModel = _mapperClass.ConvertCustomerToCustomerViewModel(c1);
            return customerViewModel;

        }
    }
}
