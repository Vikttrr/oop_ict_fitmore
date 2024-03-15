namespace FitmoRE.Application.DTO;

public class AddTrainingDto
{
    public string RoomId { get; set; } = string.Empty;

    public string EmployeeId { get; set; } = string.Empty;

    public int ParticipantsNumber { get; set; }

    public string? StartTime { get; set; }

    public string? EndTime { get; set; }

    public string? Description { get; set; } = string.Empty;
}
