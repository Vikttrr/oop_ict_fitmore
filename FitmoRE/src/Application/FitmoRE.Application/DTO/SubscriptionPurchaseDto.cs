namespace FitmoRE.Application.DTO;

public class SubscriptionPurchaseDto
{
    public string ClientId { get; set; } = string.Empty;

    public string SubscriptionId { get; set; } = string.Empty;

    public string DateTime { get; set; } = string.Empty;

    public decimal Amount { get; set; }
}
