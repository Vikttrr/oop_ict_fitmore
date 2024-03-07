namespace FitmoRE.Application.DTO;

public class SubscriptionPurchaseDto
{
    public int ClientId { get; set; }

    public string SubscriptionId { get; set; } = string.Empty;

    public string DateTime { get; set; } = string.Empty;

    public decimal Amount { get; set; }
}
