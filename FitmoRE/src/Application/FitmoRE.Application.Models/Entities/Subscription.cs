namespace FitmoRE.Application.Models.Entities;

public class Subscription
{
    public int SubscriptionId { get; set; }

    public string Type { get; set; }

    public decimal Price { get; set; }

    public DateTime StartDate { get; set; }

    public TimeSpan Duration { get; set; }

    public string Category { get; set; }

    public Subscription(int subscriptionId, string type, decimal price, DateTime startDate, TimeSpan duration, string category)
    {
        SubscriptionId = subscriptionId;
        Type = type;
        Price = price;
        StartDate = startDate;
        Duration = duration;
        Category = category;
    }
}
