namespace FitmoRE.Application.Models.Entities;

public class FitnessService
{
    public string ServiceId { get; set; }

    public int RoomId { get; set; }

    public int EmployeeId { get; set; }

    public TimeSpan Duration { get; set; }

    public decimal Cost { get; set; }

    public string Description { get; set; }

    public string Type { get; set; }

    public FitnessService(string serviceId, int roomId, int employeeId, TimeSpan duration, decimal cost, string type, string description)
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
