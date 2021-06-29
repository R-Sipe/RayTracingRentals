using RayTracingRentals.Data;
using RayTracingRentals.Models.RentalOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingRentals.Services
{
    public class RentalOrderService
    {
        //public bool CreateRentalOrder(RentalOrderCreate create)
        //{

        //}


        public IEnumerable<RentalOrderListItem> GetRentalOrders()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .RentalOrders
                    .Select(
                        e =>
                            new RentalOrderListItem
                            {
                                RentalOrderId = e.RentalOrderId,
                                Name = e.Name,
                                TotalPrice = e.TotalPrice,
                                Created = e.Created
                            }
                        );
                return query.ToArray();
            }
        }
    }
}
