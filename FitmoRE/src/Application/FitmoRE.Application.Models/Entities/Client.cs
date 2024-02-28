namespace FitmoRE.Application.Models.Entities;

public class Client
{
    public int ClientId { get; set; }

    public string FullName { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }

    public string Address { get; set; }

    public string SubscriptionType { get; set; }

    public Client(int clientId, string fullName, DateTime dateOfBirth, string phoneNumber, string email, string address, string subscriptionType)
    {
        ClientId = clientId;
        FullName = fullName;
        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber;
        Email = email;
        Address = address;
        SubscriptionType = subscriptionType;
    }
}
