using Microsoft.AspNet.Identity;
using RayTracingRental.Data;
using RayTracingRentals.Models;
using RayTracingRentals.Models.Products;
using RayTracingRentals.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RayTracingRentalsMVC.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProductService(userId);
            var model = service.GetProducts();
            return View(model);
        }

        //GET: create
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
        public ActionResult Create(ProductCreate product)
        {
            if (!ModelState.IsValid) return View(product);

            var service = CreateProductService();

            if (service.CreateProduct(product))
            {
                TempData["SaveResult"] = "The product has been created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Product could not be created");
            return View(product);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateProductService();
            var model = svc.GetProductById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateProductService().GetProductById(id);

            List<RentalOrder> orders = (new RentalOrderService()).GetRentalOrderList().ToList();
            ViewBag.RentalOrderId = orders.Select(o => new SelectListItem()
            {
                Value = o.RentalOrderId.ToString(),
                Text = o.Name,
            });

            return View(new ProductEdit
            {
                RentalOrderId = service.RentalOrderId,
                ProductId = service.ProductId,
                Name = service.Name,
                Price = service.Price,
                Console = service.Console,
                FamilyFriendly = service.FamilyFriendly
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductEdit edit)
        {
            if (!ModelState.IsValid) return View(edit);

            if(edit.ProductId != id)
            {
                ModelState.AddModelError("", "Id does not match.");
                return View(edit);
            }

            var service = CreateProductService();

            if (service.UpdateProduct(edit))
            {
                TempData["SaveResult"] = "The product has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Product could not be updated.");
            return View(edit);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateProductService();
            var model = svc.GetProductById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteById(int id)
        {
            var service = CreateProductService();
            service.DeleteProduct(id);
            TempData["SaveResult"] = "The product was deleted.";
            return RedirectToAction("Index");
        }

        private ProductService CreateProductService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProductService(userId);
            return service;
        }
    }
}