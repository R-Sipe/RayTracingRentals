using Microsoft.AspNet.Identity;
using RayTracingRental.Data;
using RayTracingRentals.Models.Customers;
using RayTracingRentals.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RayTracingRentalsMVC.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CustomerService(userId);
            var model = service.GetCustomers();
            return View(model);
        }

        public ActionResult Create()
        {
            List<RentalOrder> orders = (new RentalOrderService()).GetRentalOrderList().ToList();
            ViewBag.RentalOrderId = orders.Select(o => new SelectListItem
            {
                Value = o.RentalOrderId.ToString(),
                Text = o.Name,
            });
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerCreate product)
        {
            if (!ModelState.IsValid) return View(product);

            var service = CreateCustomerService();

            if (service.CreateCustomer(product))
            {
                TempData["SaveResult"] = "The customer has been created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Customer could not be created");
            return View(product);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateCustomerService();
            var model = svc.GetCustomerById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {


            var service = CreateCustomerService().GetCustomerById(id);

            List<RentalOrder> orders = (new RentalOrderService()).GetRentalOrderList().ToList();
            ViewBag.RentalOrderId = orders.Select(o => new SelectListItem()
            {
                Value = o.RentalOrderId.ToString(),
                Text = o.Name,
            });

            return View(new CustomerEdit
            {
                CustomerId = service.CustomerId,
                Name = service.Name,
                Email = service.Email,
                PaymentType = service.PaymentType,
                RentalOrderId = service.RentalOrderId,
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomerEdit edit)
        {
            if (!ModelState.IsValid) return View(edit);

            if (edit.CustomerId != id)
            {
                ModelState.AddModelError("", "Id does not match.");
                return View(edit);
            }

            var service = CreateCustomerService();

            if (service.UpdateCustomer(edit))
            {
                TempData["SaveResult"] = "The customer has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Customer could not be updated.");
            return View(edit);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCustomerService();
            var model = svc.GetCustomerById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteById(int id)
        {
            var service = CreateCustomerService();
            service.DeleteCustomer(id);
            TempData["SaveResult"] = "The product was deleted.";
            return RedirectToAction("Index");
        }

        private CustomerService CreateCustomerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CustomerService(userId);
            return service;
        }
    }
}