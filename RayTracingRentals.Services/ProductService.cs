using RayTracingRentals.Data;
using RayTracingRentals.Models;
using RayTracingRentals.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingRentals.Services
{
    public class ProductService
    {
        private readonly Guid _userId;

        public ProductService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateProduct(ProductCreate create)
        {
            var entity =
                new Product()
                {
                    GameId = _userId,
                    Name = create.Name,
                    Price = create.Price,
                    FamilyFriendly = create.FamilyFriendly,
                    Console = create.Console
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Products.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ProductListItem> GetProducts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Products
                    .Where(e => e.GameId == _userId)
                    .Select(
                        e =>
                            new ProductListItem
                            {
                                ProductId = e.ProductId,
                                Name = e.Name,
                                Price = e.Price
                            }
                        );
                return query.ToArray();
            }
        }

        public ProductDetail GetProductById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Products
                    .Single(e => e.ProductId == id && e.GameId == _userId);
                return
                    new ProductDetail
                    {
                        ProductId = entity.ProductId,
                        Name = entity.Name,
                        Price = entity.Price,
                        FamilyFriendly = entity.FamilyFriendly,
                        Console = entity.Console,
                    };
            }
        }
    }
}
