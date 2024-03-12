namespace FitmoRE.Infrastructure.Persistence.Entities;

public partial class TrainingSession
{
    public int Trainingid { get; set; }

    public int? Roomid { get; set; }

    public int Employeeid { get; set; }

    public int? Numberofparticipants { get; set; }

    public DateTimeOffset? Starttime { get; set; }

    public DateTimeOffset? Endtime { get; set; }

    public string? Description { get; set; }
}
