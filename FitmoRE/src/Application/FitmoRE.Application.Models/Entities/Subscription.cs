namespace FitmoRE.Application.Models.Entities;

public class Subscription
{
    public int SubscriptionId { get; set; }

    public decimal Price { get; set; }

    public string StartDate { get; set; }

    public string Duration { get; set; }

    public bool IsActive { get; set; }

    public Subscription(int subscriptionId, decimal price, string startDate, string duration, bool isActive)
    {
        SubscriptionId = subscriptionId;
        Price = price;
        StartDate = startDate;
        Duration = duration;
        IsActive = isActive;
    }
}
