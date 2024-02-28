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

    public decimal Salary { get; set; }

    public bool IsOwner { get; set; }

    public string Type { get; set; }

    public Employee(int employeeid, string fullName, string phoneNumber, string email, DateTime startDate, string workSchedule, string position, decimal salary, bool isOwner, string type)
    {
        EmployeeId = employeeid;
        FullName = fullName;
        PhoneNumber = phoneNumber;
        Email = email;
        StartDate = startDate;
        WorkSchedule = workSchedule;
        Position = position;
        Salary = salary;
        IsOwner = isOwner;
        Type = type;
    }
}
