namespace FitmoRE.Application.Models.Entities;

public class Client
{
    public string ClientId { get; set; }

    public string? FullName { get; set; }

    public string? DateOfBirth { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string Address { get; set; }

    public bool IsActive { get; set; }

    public Client(string clientId, string? fullName, string? dateOfBirth, string? phoneNumber, string? email, string address, bool isActive)
    {
        ClientId = clientId;
        FullName = fullName;
        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber;
        Email = email;
        Address = address;
        IsActive = isActive;
    }

    public Client()
    {
        throw new NotImplementedException();
    }
}