namespace FitmoRE.Infrastructure.Persistence.Entities;

public partial class GymRoom
{
    public int Roomid { get; set; }

    public string? Roomnumber { get; set; }

    public int? Space { get; set; }

    public double? Temperature { get; set; }

    public int? Capacity { get; set; }

    public int? Branchid { get; set; }
}
