namespace FitmoRE.Application.Models.Entities;

public class Client
{
    public string ClientId { get; set; }

    public string? FullName { get; set; }

    public string? DateOfBirth { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public bool IsActive { get; set; }

    public Client(string clientId, string? fullName, string? dateOfBirth, string? phoneNumber, string? email, bool isActive)
    {
        ClientId = clientId;
        FullName = fullName;
        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber;
        Email = email;
        IsActive = isActive;
    }

    public Client()
    {
        ClientId = string.Empty;
    }
}