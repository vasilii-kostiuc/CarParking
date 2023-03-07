using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking.Models.Entities
{
    public class Parking
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int VehicleId { get; set; }
        public int ZoneId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Decimal TotalPrice { get; set; } = Decimal.Zero;
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public virtual User User { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual Zone Zone { get; set; }
    }
}
