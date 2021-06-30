using RayTracingRentals.Data;
using RayTracingRentals.Models.TheRentalStore;
using RayTracingRentals.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RayTracingRentalsMVC.Controllers
{
    public class RentalStoreController : Controller
    {
        // GET: RentalStore
        public ActionResult Index()
        {
            var rentalOrder = CreateRentalStoreService();
            var order = rentalOrder.GetRentalStores();
            return View(order);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RentalStoreCreate store)
        {
            if (!ModelState.IsValid) return View(store);

            var service = CreateRentalStoreService();

            if (service.CreateRentalStore(store))
            {
                TempData["SaveResult"] = "The store has been created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "The store could not be created");
            return View(store);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateRentalStoreService();
            var model = svc.GetRentalStoreById(id);

            return View(model);
        }


        private RentalStoreService CreateRentalStoreService()
        {
            var rentalService = new RentalStoreService();
            return rentalService;
        }
    }
}