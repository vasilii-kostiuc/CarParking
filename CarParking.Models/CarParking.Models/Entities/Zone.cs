﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking.Models.Entities
{
    public class Zone: Entity
    {
        public string Name { get; set; }
        public decimal PricePerHour { get; set; }
    }
}
