using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingRentals.Models.Customer
{
    public class CustomerDetail
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string PaymentType { get; set; }
    }
}
