using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingRentals.Models.Customers
{
    public class CustomerListItem
    {
        [Display(Name = "Customer ID")]

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        [Display(Name = "Payment Type")]

        public string PaymentType { get; set; }
    }
}
