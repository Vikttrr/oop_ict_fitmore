namespace FitmoRE.Application.DTO
{
    public class PurchaseSubscriptionDto
    {
        public int ClientId { get; set; }

        public string SubscriptionId { get; set; } = string.Empty;

        public string PaymentMethod { get; set; } = string.Empty;

        public decimal Amount { get; set; }
    }
}