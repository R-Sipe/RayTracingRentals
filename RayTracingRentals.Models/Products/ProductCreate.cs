using RayTracingRentals.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingRentals.Models.Products
{
    public class ProductCreate
    {
        [Required]
        [MaxLength(100, ErrorMessage ="Too many characters, 100 limit.")]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Family Friendly")]

        public bool FamilyFriendly { get; set; }

        [Required]
        public GameConsole Console { get; set; }

        [Display(Name = "Rental Order")]

        public int RentalOrderId { get; set; }

        //public SelectList 
    }
}
