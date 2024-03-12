namespace FitmoRE.Application.Models.Entities;

public class Subscription
{
    public string SubscriptionId { get; set; }

    public decimal Price { get; set; }

    public string StartDate { get; set; }

    // public string Duration { get; set; }
    public Tariff Tariff { get; set; }

    public string ClientId { get; set; }

    public bool IsActive { get; set; }

    public Subscription(string subscriptionId, decimal price, string startDate, Tariff tariff, string clientId, bool isActive)
    {
        SubscriptionId = subscriptionId;
        Price = price;
        StartDate = startDate;
        Tariff = tariff;
        ClientId = clientId;
        IsActive = isActive;
    }
}
