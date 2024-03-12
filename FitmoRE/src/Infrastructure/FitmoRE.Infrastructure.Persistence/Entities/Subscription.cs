namespace FitmoRE.Infrastructure.Persistence.Entities;

public partial class Subscription
{
    public int Subscriptionid { get; set; }

    public decimal? Price { get; set; }

    public DateOnly? Startdate { get; set; }

    public string? Duration { get; set; }

    public bool? Isactive { get; set; }
}
