namespace FitmoRE.Infrastructure.Persistence.Entities;

public partial class Subscription
{
    public string Subscriptionid { get; set; } = null!;

    public decimal? Price { get; set; }

    public string? Startdate { get; set; }

    public string? Duration { get; set; }

    public bool? Isactive { get; set; }

    public string? Clientid { get; set; }

    public string? Tariffid { get; set; }

    public virtual Client? Client { get; set; }

    public virtual Tariff? Tariff { get; set; }
}
