namespace FitmoRE.Infrastructure.Persistence.Entities;

public partial class Employee
{
    public string EmployeeId { get; set; } = null!;

    public string? Fullname { get; set; }

    public string? Phonenumber { get; set; }

    public string? Email { get; set; }

    public DateOnly? Startdate { get; set; }

    public DateOnly? Workschedule { get; set; }

    public string? Position { get; set; }

    public bool? Isactive { get; set; }

#pragma warning disable CA2227
    public virtual ICollection<FitnessService> FitnessServices { get; set; } = new List<FitnessService>();
#pragma warning restore CA2227

#pragma warning disable CA2227
    public virtual ICollection<TrainingSession> TrainingSessions { get; set; } = new List<TrainingSession>();
#pragma warning restore CA2227
}
