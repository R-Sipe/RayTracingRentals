﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingRentals.Models.RentalOrder
{
    public class RentalOrderEdit
    {
        public int RentalOrderId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset? Returned { get; set; }
    }
}