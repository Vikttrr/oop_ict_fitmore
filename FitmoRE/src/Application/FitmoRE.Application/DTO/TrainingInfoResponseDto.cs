namespace FitmoRE.Application.DTO;

public class TrainingInfoResponseDto
{
    public string RoomId { get; set; } = string.Empty;

    public string EmployeeId { get; set; } = string.Empty;

    public int ParticipantsNumber { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public string Description { get; set; } = string.Empty;
}