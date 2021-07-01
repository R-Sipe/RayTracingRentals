using RayTracingRental.Data;
using RayTracingRentals.Data;
using RayTracingRentals.Models.TheRentalStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingRentals.Services
{
    public class RentalStoreService
    {
        public bool CreateRentalStore(RentalStoreCreate create)
        {
            var entity =
                new RentalStore()
                {
                    StoreName = create.StoreName,
                    Location = create.Location,
                    Website = create.Website,
                    PhoneNumber = create.PhoneNumber
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.RentalStores.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RentalStoreListItem> GetRentalStores()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .RentalStores
                    .Select(
                        e =>
                            new RentalStoreListItem
                            {
                                RentalStoreId = e.RentalStoreId,
                                StoreName = e.StoreName,
                                Location = e.Location
                            }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<RentalStore> GetRentalStoreList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.RentalStores.ToList();
            }
        }

        public RentalStoreDetail GetRentalStoreById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .RentalStores
                    .Single(e => e.RentalStoreId == id);
                return
                    new RentalStoreDetail()
                    {
                        RentalStoreId = entity.RentalStoreId,
                        StoreName = entity.StoreName,
                        Location = entity.Location,
                        PhoneNumber = entity.PhoneNumber,
                        Website = entity.Website,

                        RentalOrders = entity.RentalOrders.Select(e => new RentalOrder()
                        {
                            RentalStoreId = entity.RentalStoreId,
                            RentalOrderId = e.RentalOrderId,
                            Name = e.Name,
                            Created = e.Created,
                            Clerk = e.Clerk,
                            TotalPrice = e.TotalPrice
                        }).ToList()
                    };
            }
        }

        public bool UpdateRentalStore(RentalStoreEdit edit)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .RentalStores
                        .Single(e => e.RentalStoreId == edit.RentalStoreId);

                entity.StoreName = edit.StoreName;
                entity.Location = edit.Location;
                entity.PhoneNumber = edit.PhoneNumber;
                entity.Website = edit.Website;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRentalStore(int rentalStoreId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.RentalStores
                    .Single(e => e.RentalStoreId == rentalStoreId);
                ctx.RentalStores.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
