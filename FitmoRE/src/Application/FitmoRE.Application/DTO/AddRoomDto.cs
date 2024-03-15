namespace FitmoRE.Application.DTO;

public class AddRoomDto
{
    public int RoomNumber { get; set; }

    public int Space { get; set; }

    public string? Temperature { get; set; }

    public int Capacity { get; set; }

    public string BranchId { get; set; } = string.Empty;
}