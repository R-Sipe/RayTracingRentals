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

        decimal Total = 0;
        public decimal TotalPrice
        {
            get
            {
                foreach (Product product in Products)
                {
                    Total += product.Price;
                }
                return Total;
            }
        }
        public int CustomerId { get; set; }
        public virtual List<Customer> Customers { get; set; }
        public int ProductId { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
