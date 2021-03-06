using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingRentals.Models.RentalOrders
{
    public class RentalOrderCreate
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Clerk { get; set; }

        [Required]
        [Display(Name = "Rental Store")]

        public int RentalStoreId { get; set; }

    }
}
