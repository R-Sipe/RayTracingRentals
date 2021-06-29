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
        public int CustomerId { get; set; }

        public Guid RenterId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PaymentType { get; set; }

        public int RentalOrderId { get; set; }
    }
}
