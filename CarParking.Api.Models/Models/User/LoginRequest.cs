using System.ComponentModel.DataAnnotations;

namespace CarParking.Api.Models.Models.User
{
    public class LoginRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
