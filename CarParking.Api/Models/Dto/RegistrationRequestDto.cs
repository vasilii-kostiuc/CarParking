namespace CarParking.Api.Models.Dto
{
    public class RegistrationRequestDto
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Confirmation { get; set; }
    }
}
