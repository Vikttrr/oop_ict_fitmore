namespace FitmoRE.Infrastructure.Persistence.Entities;

public partial class Tariff
{
    public string Tariffid { get; set; } = null!;

    public string? Tariffcategoryid { get; set; }

    public string Tarifftypeid { get; set; } = null!;

#pragma warning disable CA2227
    public virtual ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
#pragma warning restore CA2227

    public virtual TariffCategory? Tariffcategory { get; set; }

    public virtual TariffType Tarifftype { get; set; } = null!;
}
