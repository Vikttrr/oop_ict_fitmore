namespace FitmoRE.Application.DTO;

public class RoomInfoResponseDto
{
    public int RoomNum { get; set; }

    public int Space { get; set; }

    public string Temperature { get; set; } = string.Empty;

    public int Capacity { get; set; }

    public int BranchId { get; set; }
}