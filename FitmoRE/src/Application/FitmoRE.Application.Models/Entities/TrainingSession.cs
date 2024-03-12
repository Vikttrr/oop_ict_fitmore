namespace FitmoRE.Application.Models.Entities;
public class TrainingSession
{
    public int TrainingId { get; set; }

    public int RoomId { get; set; }

    public int TrainerId { get; set; }

    public int EmployeeId { get; set; }

    public int NumberOfParticipants { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public string Description { get; set; }

    public TrainingSession(int trainingId, int roomId, int employeeId, int trainerId, int numberOfParticipants, DateTime startTime, DateTime endTime, string description)
    {
        EmployeeId = employeeId;
        RoomId = roomId;
        TrainerId = trainerId;
        NumberOfParticipants = numberOfParticipants;
        StartTime = startTime;
        EndTime = endTime;
        Description = description;
    }
}
