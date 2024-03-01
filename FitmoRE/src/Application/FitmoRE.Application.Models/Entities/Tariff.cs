namespace FitmoRE.Application.Models.Entities;

public class Tariff
{
    public TariffCategory Category { get; set; }

    public TariffType Type { get; set; }

    public Tariff(TariffCategory category, TariffType type)
    {
        Category = category;
        Type = type;
    }
}