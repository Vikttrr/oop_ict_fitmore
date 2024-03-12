namespace FitmoRE.Application.Models.Entities;

public class FitnessService
{
    public string ServiceId { get; set; }

    public string RoomId { get; set; }

    public string EmployeeId { get; set; }

    public TimeSpan Duration { get; set; }

    public decimal Cost { get; set; }

    public string Description { get; set; }

    public string Type { get; set; }

    public FitnessService(string serviceId, string roomId, string employeeId, TimeSpan duration, decimal cost, string type, string description)
    {
        ServiceId = serviceId;
        RoomId = roomId;
        EmployeeId = employeeId;
        Duration = duration;
        Cost = cost;
        Type = type;
        Description = description;
    }
}
