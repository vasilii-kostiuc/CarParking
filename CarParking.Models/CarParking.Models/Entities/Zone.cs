using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking.Models.Entities
{
    public class Zone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PricePerGour { get; set; }
    }
}
