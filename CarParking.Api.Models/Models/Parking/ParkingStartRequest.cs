﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking.Api.Models.Models.Parking
{
    public class ParkingStartRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int VehicleId { get; set; }
        [Required]
        public int ZoneId { get; set; }
    }
}
