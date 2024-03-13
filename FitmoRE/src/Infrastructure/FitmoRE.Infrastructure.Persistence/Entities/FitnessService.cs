namespace FitmoRE.Infrastructure.Persistence.Entities;

public partial class FitnessService
{
    public string Serviceid { get; set; } = null!;

    public string? Roomid { get; set; }

    public string? Employeeid { get; set; }

    public string? Duration { get; set; }

    public decimal? Cost { get; set; }

    public string? Description { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual GymRoom? Room { get; set; }
}
