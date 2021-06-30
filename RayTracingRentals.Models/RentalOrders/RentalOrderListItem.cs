using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingRentals.Models.RentalOrders
{
    public class RentalOrderListItem
    {
        public int RentalOrderId { get; set; }
        public string Name { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTimeOffset Created { get; set; }
    }
}
