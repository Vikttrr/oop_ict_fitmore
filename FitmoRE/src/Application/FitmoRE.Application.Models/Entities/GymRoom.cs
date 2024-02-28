namespace FitmoRE.Application.Models.Entities;
public class GymRoom
{
    public int RoomId { get; set; }

    public string RoomNumber { get; set; }

    public List<int> EquipmentIds { get; set; }

    public int Space { get; set; }

    public string Temperature { get; set; }

    public int Capacity { get; set; }

    public bool IsPool { get; set; }

    public bool HasFitnessEquipment { get; set; }

    public bool IsGroupExerciseRoom { get; set; }

    public bool IsAerobicsRoom { get; set; }

    public GymRoom(int roomID, List<int> equipmentIds, string roomNum, List<int> equipmentID, int space, string temperature, int capacity, bool isPool, bool hasFitnessEquipment, bool isGroupExerciseRoom, bool isAerobicsRoom)
    {
        RoomId = roomID;
        RoomNumber = roomNum;
        EquipmentIds = equipmentIds;
        Space = space;
        Temperature = temperature;
        Capacity = capacity;
        IsPool = isPool;
        HasFitnessEquipment = hasFitnessEquipment;
        IsGroupExerciseRoom = isGroupExerciseRoom;
        IsAerobicsRoom = isAerobicsRoom;
    }
}