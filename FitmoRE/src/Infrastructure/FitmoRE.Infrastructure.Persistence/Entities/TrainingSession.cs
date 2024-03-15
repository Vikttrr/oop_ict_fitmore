namespace FitmoRE.Infrastructure.Persistence.Entities;

public partial class TrainingSession
{
    public string Trainingid { get; set; } = null!;

    public string? Roomid { get; set; }

    public string Employeeid { get; set; } = null!;

    public int? Numberofparticipants { get; set; }

    public string? Starttime { get; set; }

    public string? Endtime { get; set; }

    public string? Description { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual GymRoom? Room { get; set; }

#pragma warning disable CA2227
    public virtual ICollection<TrainingRegistration> TrainingRegistrations { get; set; } = new List<TrainingRegistration>();
#pragma warning restore CA2227
}
