namespace FitmoRE.Application.Models.Entities;

public class TrainingSession
{
    public int TrainingId { get; set; }

    public int RoomId { get; set; }

    public int EmployeeId { get; set; }

    public int EquipmentId { get; set; }

    public int TrainerId { get; set; }

    public int NumberOfParticipants { get; set; }

    public DateTime Time { get; set; }

    public TimeSpan Duration { get; set; }

    public string Description { get; set; }

    public TrainingSession(int trainingId, int employeeId, int roomId, int trainerId, int equipmentId, int numberOfParticipants, DateTime time, TimeSpan duration, string description)
    {
        EmployeeId = employeeId;
        RoomId = roomId;
        TrainerId = trainerId;
        EquipmentId = equipmentId;
        NumberOfParticipants = numberOfParticipants;
        Time = time;
        Duration = duration;
        Description = description;
    }
}