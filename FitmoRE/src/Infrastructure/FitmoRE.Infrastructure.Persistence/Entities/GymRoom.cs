namespace FitmoRE.Infrastructure.Persistence.Entities;

public partial class GymRoom
{
    public string Roomid { get; set; } = null!;

    public int RoomNumber { get; set; }

    public int? Space { get; set; }

    public string? Temperature { get; set; }

    public int? Capacity { get; set; }

    public string? BranchId { get; set; }

    public virtual Branch? Branch { get; set; }

#pragma warning disable CA2227
    public virtual ICollection<FitnessService> FitnessServices { get; set; } = new List<FitnessService>();
#pragma warning restore CA2227

#pragma warning disable CA2227
    public virtual ICollection<TrainingSession> TrainingSessions { get; set; } = new List<TrainingSession>();
#pragma warning restore CA2227
}
