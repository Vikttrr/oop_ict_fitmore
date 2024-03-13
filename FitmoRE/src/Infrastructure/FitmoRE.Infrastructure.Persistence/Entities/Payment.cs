namespace FitmoRE.Infrastructure.Persistence.Entities;

public partial class Payment
{
    public string Paymentid { get; set; } = null!;

    public string? Clientid { get; set; }

    public DateOnly? Date { get; set; }

    public decimal? Amount { get; set; }

    public bool? Ispaid { get; set; }

    public virtual Client? Client { get; set; }
}
