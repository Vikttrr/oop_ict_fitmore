namespace FitmoRE.Application.DTO;

public class SubscriptionPurchaseResponseDto
{
    public string PaymentId { get; set; } = string.Empty;

    public bool? IsPaid { get; set; }
}