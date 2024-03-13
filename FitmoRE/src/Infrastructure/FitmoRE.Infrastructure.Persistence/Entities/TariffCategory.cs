namespace FitmoRE.Infrastructure.Persistence.Entities;

public partial class TariffCategory
{
    public string Tariffcategoryid { get; set; } = null!;

    public char Category { get; set; }

#pragma warning disable CA2227
    public virtual ICollection<Tariff> Tariffs { get; set; } = new List<Tariff>();
#pragma warning restore CA2227
}
