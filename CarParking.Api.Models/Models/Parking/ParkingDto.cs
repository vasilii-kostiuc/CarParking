using CarParking.Api.Models.Models.Vehicle;
using CarParking.Api.Models.Models.Zone;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking.Api.Models.Models.Parking
{
    public class ParkingDto
    {
        public int Id { get; set; }
        public ZoneDto Zone { get; set; }
        public VehicleDto Vehicle { get; set; }
        public decimal TotalPrice { get; set; } = decimal.Zero;
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
