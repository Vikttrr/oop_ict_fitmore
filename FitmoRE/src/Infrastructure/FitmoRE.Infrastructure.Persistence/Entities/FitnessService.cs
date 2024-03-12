namespace FitmoRE.Infrastructure.Persistence.Entities;

public partial class FitnessService
{
    public int Serviceid { get; set; }

    public int? Roomid { get; set; }

    public int? Employeeid { get; set; }

    public string? Duration { get; set; }

    public decimal? Cost { get; set; }

    public string? Description { get; set; }
}
