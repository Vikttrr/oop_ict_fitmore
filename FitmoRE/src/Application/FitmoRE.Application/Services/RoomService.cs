using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Models;
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
        Models.Models.GymRoomModel roomModel = _roomRepository.GetById(roomId);
        if (string.IsNullOrEmpty(roomModel.RoomId))
        {
            return new RoomInfoResponseDto()
            {
                BranchId = string.Empty,
            };
        }

        return new RoomInfoResponseDto
        {
            RoomNum = roomModel.RoomNumber,
            Space = roomModel.Space,
            Temperature = roomModel.Temperature,
            Capacity = roomModel.Capacity,
            BranchId = roomModel.BranchId,
        };
    }

    public AddRoomResponseDto Add(AddRoomDto addRoomDto)
    {
        string id = new Random().Next().ToString();
        var gymRoom = new GymRoomModel(
            id,
            addRoomDto.RoomNumber,
            addRoomDto.Space,
            addRoomDto.Temperature,
            addRoomDto.Capacity,
            addRoomDto.BranchId);

        string newId = _roomRepository.Add(gymRoom);

        return new AddRoomResponseDto
        {
            RoomId = newId,
        };
    }
}