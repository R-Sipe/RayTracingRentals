using RayTracingRental.Data;
using RayTracingRentals.Data;
using RayTracingRentals.Models.Customer;
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
    }
}
