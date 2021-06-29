using RayTracingRentals.Models.RentalOrder;
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




        private RentalOrderService CreateRentalOrderService()
        {
            var rentalService = new RentalOrderService();
            return rentalService;
        }
    }
}