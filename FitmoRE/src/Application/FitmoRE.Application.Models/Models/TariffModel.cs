namespace FitmoRE.Application.Models.Models;

public class TariffModel
{
    public TariffCategory Category { get; set; }

    public TariffType Type { get; set; }

    public TariffModel()
    {
        // Empty constructor
    }

    public TariffModel(TariffCategory category, TariffType type)
    {
        Category = category;
        Type = type;
    }
}