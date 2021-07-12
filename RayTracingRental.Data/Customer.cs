using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingRental.Data
{
    public class Customer
    {
        [Key]
        [Display(Name = "Customer ID")]
        public int CustomerId { get; set; }

        public Guid RenterId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Payment Type")]

        public string PaymentType { get; set; }

        public int RentalOrderId { get; set; }
        //public RentalOrder RentalOrder { get; set; }
    }
}
