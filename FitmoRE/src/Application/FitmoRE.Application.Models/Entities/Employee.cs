namespace FitmoRE.Application.Models.Entities;

public class Employee
{
    public string EmployeeId { get; set; } = string.Empty;

    public string? FullName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? StartDate { get; set; }

    public string? WorkSchedule { get; set; }

    public string? Position { get; set; }

    public bool? IsActive { get; set; }

    public Employee(string employeeId, string? fullName, string? phoneNumber, string? email, string? startDate, string? workSchedule, string? position, bool isActive)
    {
        EmployeeId = employeeId;
        FullName = fullName;
        PhoneNumber = phoneNumber;
        Email = email;
        StartDate = startDate;
        WorkSchedule = workSchedule;
        Position = position;
        IsActive = isActive;
    }

    public Employee()
    {
        EmployeeId = string.Empty;
    }
}
