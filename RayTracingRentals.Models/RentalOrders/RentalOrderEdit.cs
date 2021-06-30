using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingRentals.Models.RentalOrders
{
    public class RentalOrderEdit
    {
        public int RentalOrderId { get; set; }
        public string Name { get; set; }
        public string Clerk { get; set; }
        public DateTimeOffset? Returned { get; set; }
    }
}
