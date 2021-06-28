using Microsoft.AspNet.Identity;
using RayTracingRentals.Models;
using RayTracingRentals.Models.Product;
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

        private ProductService CreateProductService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProductService(userId);
            return service;
        }
    }
}