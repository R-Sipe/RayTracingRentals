using RayTracingRental.Data;
using RayTracingRentals.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingRentals.Models.RentalOrders
{
    public class RentalOrderDetail
    {
        [Display(Name = "Rental Order ID")]

        public int RentalOrderId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Returned { get; set; }
        public string Clerk { get; set; }

        decimal Total = 0;
        [Display(Name = "Total Price")]
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
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        [Display(Name = "Rental Store")]

        public int RentalStoreId { get; set; }
    }
}
