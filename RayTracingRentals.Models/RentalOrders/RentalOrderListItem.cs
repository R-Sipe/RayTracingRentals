using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingRentals.Models.RentalOrders
{
    public class RentalOrderListItem
    {
        [Display(Name = "Rental Order ID")]

        public int RentalOrderId { get; set; }
        public string Name { get; set; }

        [Display(Name = "Total Price")]

        public decimal TotalPrice { get; set; }
        public DateTimeOffset Created { get; set; }
    }
}
