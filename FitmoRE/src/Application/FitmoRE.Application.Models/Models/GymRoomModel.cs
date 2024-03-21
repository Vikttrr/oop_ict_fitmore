namespace FitmoRE.Application.Models.Models;
public class GymRoomModel
{
    public string RoomId { get; set; }

    public int RoomNumber { get; set; }

    public int? Space { get; set; }

    public string? Temperature { get; set; }

    public int? Capacity { get; set; }

    public string? BranchId { get; set; }

    public GymRoomModel(string roomId, int roomNumber, int space, string? temperature, int capacity, string? branchId)
    {
        RoomId = roomId;
        RoomNumber = roomNumber;
        Space = space;
        Temperature = temperature;
        Capacity = capacity;
        BranchId = branchId;
    }

    public GymRoomModel()
    {
       RoomId = string.Empty;
    }
}
