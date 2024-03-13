using FitmoRE.Application.Models.Entities;

namespace FitmoRE.Application.DTO;
public class AddSubscriptionDto
{
    public decimal Price { get; set; }

    public string StartDate { get; set; } = string.Empty;

    // public string Duration { get; set; } = string.Empty;
    public Tariff Tariff { get; set; } = new Tariff();

    public string UserId { get; set; } = string.Empty;

    public bool IsActive { get; set; }
}