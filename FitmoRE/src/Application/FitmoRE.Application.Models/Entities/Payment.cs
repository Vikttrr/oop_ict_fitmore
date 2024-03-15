namespace FitmoRE.Application.Models.Entities;

public class Payment
{
    public string PaymentId { get; set; }

    public string? ClientId { get; set; }

    public string? Date { get; set; }

    public decimal Amount { get; set; }

    public bool? IsPaid { get; set; }

    public Payment(string paymentId, string? clientId, string date, decimal amount, bool isPaid)
    {
        PaymentId = paymentId;
        ClientId = clientId;
        Date = date;
        Amount = amount;
        IsPaid = isPaid;
    }

    public Payment()
    {
        throw new NotImplementedException();
    }
}
