namespace FitmoRE.Application.DTO;

public class AddTrainingDto
{
    public int RoomId { get; set; }

    public int EmployeeId { get; set; }

    public int ParticipantsNumber { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public string Description { get; set; } = string.Empty;
}
