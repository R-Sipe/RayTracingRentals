using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingRentals.Models.TheRentalStore
{
    public class RentalStoreCreate
    {
        [Required]
        [Display(Name = "Store Name")]

        public string StoreName { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        [Display(Name = "Phone Number")]

        public string PhoneNumber { get; set; }

        [Required]
        public string Website { get; set; }
    }
}
