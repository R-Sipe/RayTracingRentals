using RayTracingRental.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingRentals.Models.TheRentalStore
{
    public class RentalStoreDetail
    {
        public int RentalStoreId { get; set; }
        public string StoreName { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public string Website { get; set; }
        public virtual List<RentalOrder> RentalOrders { get; set; }
    }
}
