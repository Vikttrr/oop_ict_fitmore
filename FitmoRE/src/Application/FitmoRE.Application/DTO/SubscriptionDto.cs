namespace FitmoRE.Application.DTO;

public class SubscriptionDto
{
    public string SubscriptionId { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public string StartDate { get; set; } = string.Empty;

    public string Duration { get; set; } = string.Empty;

    public bool IsActive { get; set; }
}