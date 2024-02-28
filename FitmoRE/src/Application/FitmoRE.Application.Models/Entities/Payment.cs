namespace FitmoRE.Application.Models.Entities;

public class Payment
{
    public int PaymentId { get; set; }

    public int ClientId { get; set; }

    public DateTime Date { get; set; }

    public decimal Amount { get; set; }

    public bool IsPaid { get; set; }

    public Payment(int paymentId, int clientId, DateTime date, decimal amount, bool isPaid)
    {
        PaymentId = paymentId;
        ClientId = clientId;
        Date = date;
        Amount = amount;
        IsPaid = isPaid;
    }
}
