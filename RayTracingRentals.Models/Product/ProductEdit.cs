using RayTracingRentals.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingRentals.Models.Product
{
    public class ProductEdit
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool FamilyFriendly { get; set; }
        public GameConsole Console { get; set; }
    }
}
