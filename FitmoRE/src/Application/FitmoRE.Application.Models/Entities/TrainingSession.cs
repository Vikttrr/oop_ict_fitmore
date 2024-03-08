namespace FitmoRE.Application.Models.Entities;

public class TrainingSession
{
    public int TrainingId { get; set; }

    public string RoomId { get; set; }

    public string EmployeeId { get; set; }

    public int NumberOfParticipants { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public string Description { get; set; }

    public TrainingSession(string trainingId, string roomId, string employeeId, int numberOfParticipants, DateTime startTime, DateTime endTime, string description)
    {
        EmployeeId = employeeId;
        RoomId = roomId;
        NumberOfParticipants = numberOfParticipants;
        StartTime = startTime;
        EndTime = endTime;
        Description = description;
    }
}