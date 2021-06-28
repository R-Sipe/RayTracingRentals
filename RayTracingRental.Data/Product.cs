using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingRental.Data
{
    public enum Console { PlayStation=1, Xbox, Nitendo, PC }
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public decimal Price { get; set; }
        
        [Required]
        public bool FamilyFriendly { get; set; }
        
        [Required]
        public Console Console { get; set; }
    }
}
