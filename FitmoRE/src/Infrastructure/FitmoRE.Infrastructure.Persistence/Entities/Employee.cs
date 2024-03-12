namespace FitmoRE.Infrastructure.Persistence.Entities;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? Fullname { get; set; }

    public string? Phonenumber { get; set; }

    public string? Email { get; set; }

    public DateOnly? Startdate { get; set; }

    public DateOnly? Workschedule { get; set; }

    public string? Position { get; set; }

    public bool? Isactive { get; set; }
}
