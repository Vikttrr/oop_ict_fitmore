namespace FitmoRE.Application.DTO;

public class AddEmployeeDto
{
    public int EmployeeId { get; set; }

    public string FullName { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string StartDate { get; set; } = string.Empty;

    public string WorkSchedule { get; set; } = string.Empty;

    public string Position { get; set; } = string.Empty;
}
