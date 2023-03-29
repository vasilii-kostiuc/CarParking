using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking.Api.Models.Models.User
{
    public class ProfileUpdateRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
