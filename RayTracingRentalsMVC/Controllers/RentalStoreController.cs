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

        public ActionResult Edit(int id)
        {
            var service = CreateRentalStoreService();
            var detail = service.GetRentalStoreById(id);
            var model =
                new RentalStoreEdit
                {
                    RentalStoreId = detail.RentalStoreId,
                    StoreName = detail.StoreName,
                    Location = detail.Location,
                    PhoneNumber = detail.PhoneNumber,
                    Website = detail.Website
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RentalStoreEdit edit)
        {
            if (!ModelState.IsValid) return View(edit);

            if (edit.RentalStoreId != id)
            {
                ModelState.AddModelError("", "Id does not match.");
                return View(edit);
            }

            var service = CreateRentalStoreService();

            if (service.UpdateRentalStore(edit))
            {
                TempData["SaveResult"] = "The rental store has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The rental store could not be updated.");
            return View(edit);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateRentalStoreService();
            var model = svc.GetRentalStoreById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteById(int id)
        {
            var service = CreateRentalStoreService();
            service.DeleteRentalStore(id);

            TempData["SaveResult"] = "The rental store was deleted.";
            return RedirectToAction("Index");
        }


        private RentalStoreService CreateRentalStoreService()
        {
            var rentalService = new RentalStoreService();
            return rentalService;
        }
    }
}