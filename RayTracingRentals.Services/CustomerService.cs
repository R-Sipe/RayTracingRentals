using RayTracingRental.Data;
using RayTracingRentals.Data;
using RayTracingRentals.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingRentals.Services
{
    public class CustomerService
    {
        private readonly Guid _userId;

        public CustomerService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCustomer(CustomerCreate create)
        {
            var entity =
                new Customer()
                {
                    RenterId = _userId,
                    Name = create.Name,
                    Email = create.Email,
                    PaymentType = create.PaymentType
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Customers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CustomerListItem> GetCustomers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Customers
                    .Where(e => e.RenterId == _userId)
                    .Select(
                        e =>
                        new CustomerListItem
                        {
                            CustomerId = e.CustomerId,
                            Name = e.Name,
                            Email = e.Email,
                            PaymentType = e.PaymentType
                        }
                    );
                return query.ToArray();
            }
        }

        public CustomerDetail GetCustomerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Customers
                    .Single(e => e.CustomerId == id && e.RenterId == _userId);
                return
                    new CustomerDetail
                    {
                        CustomerId = entity.CustomerId,
                        Name = entity.Name,
                        Email = entity.Email,
                        PaymentType = entity.PaymentType,
                    };
            }
        }

        public bool UpdateCustomer(CustomerEdit edit)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerId == edit.CustomerId && e.RenterId == _userId);

                entity.Name = edit.Name;
                entity.Email = edit.Email;
                entity.PaymentType = edit.PaymentType;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCustomer(int customerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Customers
                    .Single(e => e.CustomerId == customerId && e.RenterId == _userId);
                ctx.Customers.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
