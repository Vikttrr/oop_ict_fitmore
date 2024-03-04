namespace FitmoRE.Application.DTO
{
    public class AuthenticateClientDto
    {
        public string PhoneNumber { get; set; } = string.Empty;

        public int ClientId { get; set; }
    }
}