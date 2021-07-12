using RayTracingRentals.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingRentals.Models.Products
{
    public class ProductDetail
    {
        [Display(Name = "Product ID")]

        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        [Display(Name = "Family Friendly")]

        public bool FamilyFriendly { get; set; }
        public GameConsole Console { get; set; }

        [Display(Name = "Rental Order")]

        public int RentalOrderId { get; set; }
    }
}
