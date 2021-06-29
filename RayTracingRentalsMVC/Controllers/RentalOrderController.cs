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





        private RentalOrderService CreateRentalOrderService()
        {
            var rentalService = new RentalOrderService();
            return rentalService;
        }
    }
}