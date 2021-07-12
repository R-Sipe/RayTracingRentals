using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingRentals.Models.Customers
{
    public class CustomerCreate
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Payment Type")]

        public string PaymentType { get; set; }

        [Required]
        [Display(Name = "Rental Order")]

        public int RentalOrderId { get; set; }
    }
}
