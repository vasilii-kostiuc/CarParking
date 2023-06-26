using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking.Api.Models.Models.Vehicle
{
    public class VehicleCreateRequest
    {
        public string Name { get; set; }
        [Required]
        public string PlateNumber { get; set; }
        public int UserId { get; set; }
    }
}
