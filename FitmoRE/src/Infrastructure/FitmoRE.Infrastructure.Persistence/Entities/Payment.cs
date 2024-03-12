namespace FitmoRE.Infrastructure.Persistence.Entities;

public partial class Payment
{
    public int Paymentid { get; set; }

    public int? Clientid { get; set; }

    public DateOnly? Date { get; set; }

    public decimal? Amount { get; set; }

    public bool? Ispaid { get; set; }
}
