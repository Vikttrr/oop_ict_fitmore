using FitmoRE.Application.Models.Models;

namespace FitmoRE.Application.DTO;
public class AddSubscriptionDto
{
    public decimal Price { get; set; }

    public string StartDate { get; set; } = string.Empty;

    // public string Duration { get; set; } = string.Empty;
    public TariffModel TariffModel { get; set; } = new TariffModel();

    public string UserId { get; set; } = string.Empty;

    public bool IsActive { get; set; }
}