namespace FitmoRE.Application.Models.Entities;

public class Employee
{
    public int EmployeeId { get; set; }

    public string FullName { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }

    public DateTime StartDate { get; set; }

    public string WorkSchedule { get; set; }

    public string Position { get; set; }

    public bool IsActive { get; set; }

    public Employee(int id, string fullName, string phoneNumber, string email, DateTime startDate, string workSchedule, string position, bool isActive)
    {
        EmployeeId = id;
        FullName = fullName;
        PhoneNumber = phoneNumber;
        Email = email;
        StartDate = startDate;
        WorkSchedule = workSchedule;
        Position = position;
        IsActive = isActive;
    }
}
