using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking.Models.Entities
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string PlateNumber { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
