using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.ViewModels;

namespace NotAmoebaStoreApplicationMVC.Controllers
{
    public class ShopController : Controller
    {
        private BusinessLogicClass _businessLogicClass;
        public ShopController(BusinessLogicClass businessLogicClass)
        {
            _businessLogicClass = businessLogicClass;
        }
        // GET: InventoryController

        [ActionName("ShowInventory")]
        public ActionResult Index()
        {
            List<InventoryViewModel> inventoryViewModelList = _businessLogicClass.InventoryList();
            return View(inventoryViewModelList);
        }

        [ActionName("Quantity")]
        public ActionResult Quantity()
        {
            return View("Quantity");
        }

        [ActionName("DeduceQuantity")]
        public ActionResult DeduceQuantity(int quantity)
        {
            return View("DeduceQuantity" ,quantity);

        }

        // GET: InventoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InventoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InventoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InventoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InventoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InventoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InventoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
