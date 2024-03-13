namespace FitmoRE.Infrastructure.Persistence.Entities;

public partial class Branch
{
    public string BranchId { get; set; } = null!;

    public string? Address { get; set; }

    public string? Workinghours { get; set; }

#pragma warning disable CA2227
    public virtual ICollection<GymRoom> GymRooms { get; set; } = new List<GymRoom>();
#pragma warning restore CA2227
}
