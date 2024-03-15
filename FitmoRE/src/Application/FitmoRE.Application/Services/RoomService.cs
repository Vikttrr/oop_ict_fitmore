using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Entities;
using FitmoRE.Application.Repositories;
using FitmoRE.Application.Services.Interfaces;

namespace FitmoRE.Application.Services;
public class RoomService : IRoomService
{
    private readonly IRoomRepository _roomRepository;

    public RoomService(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public RoomInfoResponseDto GetRoomInfo(string roomId)
    {
        Models.Entities.GymRoom room = _roomRepository.GetById(roomId);
        if (string.IsNullOrEmpty(room.RoomId))
        {
            return new RoomInfoResponseDto()
            {
                BranchId = string.Empty,
            };
        }

        return new RoomInfoResponseDto
        {
            RoomNum = room.RoomNumber,
            Space = room.Space,
            Temperature = room.Temperature,
            Capacity = room.Capacity,
            BranchId = room.BranchId,
        };
    }

    public AddRoomResponseDto Add(AddRoomDto addRoomDto)
    {
        var id = new Random().Next().ToString();
        var gymRoom = new GymRoom(
            id,
            addRoomDto.RoomNumber,
            addRoomDto.Space,
            addRoomDto.Temperature,
            addRoomDto.Capacity,
            addRoomDto.BranchId);

        var newId = _roomRepository.Add(gymRoom);

        return new AddRoomResponseDto
        {
            RoomId = newId,
        };
    }
}