using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking.Api.Models.Models.Zone
{
    public class ZoneDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PricePerHour { get; set; }
    }
}
