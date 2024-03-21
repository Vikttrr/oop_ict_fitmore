namespace FitmoRE.Application.Models.Models;

public class ClientModel
{
    public string ClientId { get; set; }

    public string? FullName { get; set; }

    public string? DateOfBirth { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public bool IsActive { get; set; }

    public ClientModel(string clientId, string? fullName, string? dateOfBirth, string? phoneNumber, string? email, bool isActive)
    {
        ClientId = clientId;
        FullName = fullName;
        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber;
        Email = email;
        IsActive = isActive;
    }

    public ClientModel()
    {
        ClientId = string.Empty;
    }
}