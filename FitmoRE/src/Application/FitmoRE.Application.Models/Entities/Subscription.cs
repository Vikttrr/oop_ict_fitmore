namespace FitmoRE.Application.Models.Entities;

public class Subscription
{
    public int SubscriptionId { get; set; }

    public decimal Price { get; set; }

    public DateTime StartDate { get; set; }

    public TimeSpan Duration { get; set; }

    public bool IsActive { get; set; }

    public Subscription(int subscriptionId, decimal price, DateTime startDate, TimeSpan duration, bool isActive)
    {
        SubscriptionId = subscriptionId;
        Price = price;
        StartDate = startDate;
        Duration = duration;
        IsActive = isActive;
    }
}
