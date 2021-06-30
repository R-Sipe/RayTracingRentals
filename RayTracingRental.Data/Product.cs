using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingRentals.Data
{
    public enum GameConsole { PlayStation=1, Xbox, Nintendo, PC }
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public Guid GameId { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public decimal Price { get; set; }
        
        [Required]
        public bool FamilyFriendly { get; set; }
        
        [Required]
        public GameConsole Console { get; set; }

        public int RentalOrderId { get; set; }
    }
}
