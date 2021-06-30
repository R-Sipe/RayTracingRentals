using RayTracingRentals.Models.RentalOrders;
using RayTracingRentals.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RayTracingRentalsMVC.Controllers
{
    public class RentalOrderController : Controller
    {
        // GET: RentalOrder
        public ActionResult Index()
        {
            var rentalOrder = CreateRentalOrderService();
            var order = rentalOrder.GetRentalOrders();
            return View(order);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RentalOrderCreate order)
        {
            if (!ModelState.IsValid) return View(order);

            var service = CreateRentalOrderService();

            if (service.CreateRentalOrder(order))
            {
                TempData["SaveResult"] = "The order has been created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "The order could not be created");
            return View(order);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateRentalOrderService();
            var model = svc.GetRentalOrderById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateRentalOrderService();
            var detail = service.GetRentalOrderById(id);
            var model =
                new RentalOrderEdit
                {
                    RentalOrderId = detail.RentalOrderId,
                    Name = detail.Name,
                    Returned = DateTimeOffset.UtcNow
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RentalOrderEdit edit)
        {
            if (!ModelState.IsValid) return View(edit);

            if (edit.RentalOrderId != id)
            {
                ModelState.AddModelError("", "Id does not match.");
                return View(edit);
            }

            var service = CreateRentalOrderService();

            if (service.UpdateRentalOrder(edit))
            {
                TempData["SaveResult"] = "The rental order has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The rental order could not be updated.");
            return View(edit);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateRentalOrderService();
            var model = svc.GetRentalOrderById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteById(int id)
        {
            var service = CreateRentalOrderService();
            service.DeleteRentalOrder(id);
            
            TempData["SaveResult"] = "The rental order was deleted.";
            return RedirectToAction("Index");
        }

        private RentalOrderService CreateRentalOrderService()
        {
            var rentalService = new RentalOrderService();
            return rentalService;
        }
    }
}