using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingRentals.Models.TheRentalStore
{
    public class RentalStoreEdit
    {
        [Display(Name = "Store ID")]

        public int RentalStoreId { get; set; }
        [Display(Name = "Store Name")]

        public string StoreName { get; set; }
        public string Location { get; set; }
        [Display(Name = "Phone Number")]

        public string PhoneNumber { get; set; }
        public string Website { get; set; }
    }
}
