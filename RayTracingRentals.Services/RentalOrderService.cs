﻿using RayTracingRental.Data;
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
        public bool CreateRentalOrder(RentalOrderCreate create)
        {
            var entity =
                new RentalOrder()
                {
                    Name = create.Name,
                    Created = DateTimeOffset.Now,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.RentalOrders.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }


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

        public RentalOrderDetail GetRentalOrderById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .RentalOrders
                    .Single(e => e.RentalOrderId == id);
                return
                    new RentalOrderDetail()
                    {
                        RentalOrderId = entity.RentalOrderId,
                        Name = entity.Name,
                        Created = entity.Created,
                        Returned = entity.Returned,

                        Customers = entity.Customers.Select(e => new Customer()
                        {
                            RentalOrderId = entity.RentalOrderId,
                            CustomerId = e.CustomerId,
                            RenterId = e.RenterId,
                            Name = e.Name,
                            Email = e.Email,
                            PaymentType = e.PaymentType,
                        }).ToList(),

                        Products = entity.Products.Select(e => new Product()
                        {
                            RentalOrderId = entity.RentalOrderId,
                            ProductId = e.ProductId,
                            GameId = e.GameId,
                            Name = e.Name,
                            Price = e.Price,
                            FamilyFriendly = e.FamilyFriendly,
                            Console = e.Console
                        }).ToList()
                        
                    };
            }
        }

        public bool UpdateRentalOrder(RentalOrderEdit edit)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .RentalOrders
                        .Single(e => e.RentalOrderId == edit.RentalOrderId);

                entity.Name = edit.Name;
                entity.Returned = DateTimeOffset.Now;
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
