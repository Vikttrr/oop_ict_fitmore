namespace FitmoRE.Infrastructure.Persistence.Entities;

public partial class Tariff
{
    public int Tariffid { get; set; }

    public int? Tariffcategoryid { get; set; }

    public int Tarifftypeid { get; set; }
}
