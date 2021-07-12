using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingRentals.Models.TheRentalStore
{
    public class RentalStoreListItem
    {
        [Display(Name = "Store ID")]

        public int RentalStoreId { get; set; }
        [Display(Name = "Store Name")]

        public string StoreName { get; set; }
        public string Location { get; set; }
    }
}
