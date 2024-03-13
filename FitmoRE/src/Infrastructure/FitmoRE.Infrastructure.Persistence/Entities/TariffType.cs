namespace FitmoRE.Infrastructure.Persistence.Entities;

public partial class TariffType
{
    public string Tarifftypeid { get; set; } = null!;

    public char Type { get; set; }

#pragma warning disable CA2227
    public virtual ICollection<Tariff> Tariffs { get; set; } = new List<Tariff>();
#pragma warning restore CA2227
}
