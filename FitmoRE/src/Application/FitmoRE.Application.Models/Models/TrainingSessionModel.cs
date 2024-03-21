namespace FitmoRE.Application.Models.Models;

public class TrainingSessionModel
{
    public string TrainingId { get; set; }

    public string RoomId { get; set; }

    public string EmployeeId { get; set; }

    public int NumberOfParticipants { get; set; }

    public string? StartTime { get; set; }

    public string? EndTime { get; set; }

    public string? Description { get; set; }

    public TrainingSessionModel(string trainingId, string roomId, string employeeId, int numberOfParticipants, string? startTime, string? endTime, string? description)
    {
        TrainingId = trainingId;
        EmployeeId = employeeId;
        RoomId = roomId;
        NumberOfParticipants = numberOfParticipants;
        StartTime = startTime;
        EndTime = endTime;
        Description = description;
    }

    public TrainingSessionModel()
    {
        throw new NotImplementedException();
    }
}