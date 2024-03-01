namespace FitmoRE.Application.Models.Entities;
public class GymRoom
{
    public int RoomId { get; set; }

    public string RoomNumber { get; set; }

    public int Space { get; set; }

    public double Temperature { get; set; }

    public int Capacity { get; set; }

    public int BranchId { get; set; }

    public GymRoom(int roomId, string roomNumber, int space, double temperature, int capacity, int branchId)
    {
        RoomId = roomId;
        RoomNumber = roomNumber;
        Space = space;
        Temperature = temperature;
        Capacity = capacity;
        BranchId = branchId;
    }
}
