using System.ComponentModel.DataAnnotations;

namespace CarParking.Api.Models.Models.User
{
    public class RegistrationRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Confirmation { get; set; }
    }
}
