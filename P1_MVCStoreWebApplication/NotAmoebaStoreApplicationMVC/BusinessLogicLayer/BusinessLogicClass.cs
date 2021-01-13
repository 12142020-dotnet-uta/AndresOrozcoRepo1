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
                UserName = loginCustomerViewModel.UserName,
                Store = loginCustomerViewModel.Store
            };

            Customer c1 = _repository.LoginCustomer(c);

            CustomerViewModel customerViewModel = _mapperClass.ConvertCustomerToCustomerViewModel(c1);
            return customerViewModel;
        }

        public CustomerViewModel RegisterCustomer(LoginCustomerViewModel viewModel)
        {
            Customer c = new Customer()
            {
                FName = viewModel.FName,
                LName = viewModel.LName,
                UserName = viewModel.UserName,
                Store = viewModel.Store
            };
            Customer c1 = _repository.RegisterCustomer(c);

            CustomerViewModel customerViewModel = _mapperClass.ConvertCustomerToCustomerViewModel(c1);
            return customerViewModel;
        }

        public List<CustomerViewModel> CustomerList()
        {
            List<Customer> customerList = _repository.CustomerList();
            List<CustomerViewModel> customerViewModelList = new List<CustomerViewModel>();
            foreach(Customer c in customerList)
            {
                customerViewModelList.Add(_mapperClass.ConvertCustomerToCustomerViewModel(c));
            }
            return customerViewModelList;
        }

        public List<InventoryViewModel> InventoryList()
        {
            List<Inventory> inventoryList = _repository.InventoryList();
            List<InventoryViewModel> inventoryViewModelList = new List<InventoryViewModel>();
            foreach (Inventory i in inventoryList)
            {
                inventoryViewModelList.Add(_mapperClass.ConvertInventoryToInventoryModel(i));
            }
            return inventoryViewModelList;
        }

        public List<ShopViewModel> StoreList()
        {
            List<Store> storeList = _repository.StoreList();
            List<ShopViewModel> shopViewModelList = new List<ShopViewModel>();
            foreach (Store s in storeList)
            {
                shopViewModelList.Add(_mapperClass.ConvertStoreToShopViewModel(s));
            }
            return shopViewModelList;
        }

    }
}
