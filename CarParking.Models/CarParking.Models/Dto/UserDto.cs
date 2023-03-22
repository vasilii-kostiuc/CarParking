using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking.Models.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RememberToken { get; set; }
        public DateTime EmailVerifiedAt { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
