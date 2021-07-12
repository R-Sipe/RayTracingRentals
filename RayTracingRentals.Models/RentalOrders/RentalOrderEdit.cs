using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingRentals.Models.RentalOrders
{
    public class RentalOrderEdit
    {
        [Display(Name = "Rental Order ID")]

        public int RentalOrderId { get; set; }
        public string Name { get; set; }
        public string Clerk { get; set; }
        public DateTimeOffset? Returned { get; set; }
        [Display(Name = "Rental Store")]

        public int RentalStoreId { get; set; }
    }
}
