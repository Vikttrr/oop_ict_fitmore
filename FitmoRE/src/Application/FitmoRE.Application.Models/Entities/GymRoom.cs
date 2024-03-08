namespace FitmoRE.Application.Models.Entities;
public class GymRoom
{
    public string RoomId { get; set; }

    public int RoomNumber { get; set; }

    public int Space { get; set; }

    public double Temperature { get; set; }

    public int Capacity { get; set; }

    public string BranchId { get; set; }

    public GymRoom(string roomId, int roomNumber, int space, double temperature, int capacity, string branchId)
    {
        RoomId = roomId;
        RoomNumber = roomNumber;
        Space = space;
        Temperature = temperature;
        Capacity = capacity;
        BranchId = branchId;
    }
}
