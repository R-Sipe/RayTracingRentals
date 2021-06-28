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
        public int RentalOrderId { get; set; }

        [Required]
        public string Name { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Returned { get; set; }
        public decimal TotalPrice { get; set; }
        public int CustomerId { get; set; }
        public virtual List<Customer> Customer { get; set; }
        public int ProductId { get; set; }
        public virtual List<Product> Product { get; set; }
    }
}
