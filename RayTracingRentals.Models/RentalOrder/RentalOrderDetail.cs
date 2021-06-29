using RayTracingRental.Data;
using RayTracingRentals.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingRentals.Models.RentalOrder
{
    public class RentalOrderDetail
    {
        public int RentalOrderId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Returned { get; set; }
        public decimal TotalPrice { get; set; }
        public int CustomerId { get; set; }
        public virtual List<Customer> Customers { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
