using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingRental.Data
{
    public class RentalStore
    {
        [Key]
        public int RentalStoreId { get; set; }

        [Required]
        public string StoreName { get; set; }
        
        [Required]
        public string Location { get; set; }
        
        [Required]
        public string PhoneNumber { get; set; }
        
        [Required]
        public string Website { get; set; }
        public int RentalOrderId { get; set; }
        public virtual ICollection<RentalOrder> RentalOrders { get; set; } 
    }
}
