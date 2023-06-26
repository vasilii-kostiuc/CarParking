using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking.Services.Models.Vehicle
{
    public class VehicleUpdateDto
    {
        public string Name { get; set; }
        [Required]
        public string PlateNumber { get; set; }
        public int UserId { get; set; }
    }
}
