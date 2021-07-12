using RayTracingRentals.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingRental.Data
{
    public class RentalOrder
    {
        [Key]
        [Display(Name = "Rental Order ID")]

        public int RentalOrderId { get; set; }

        [Required]
        public string Name { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Returned { get; set; }

        [Display(Name = "Total Price")]

        public decimal TotalPrice { get; set; }
        public string Clerk { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public int RentalStoreId { get; set; }
    }
}
