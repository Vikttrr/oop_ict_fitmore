using FitmoRE.Application.DTO;
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

    public RoomInfoResponseDto GetRoomInfo(RoomInfoDto roomId)
    {
        Models.Entities.GymRoom room = _roomRepository.GetById(roomId.RoomId);
        if (room == null)
        {
            // throw new InvalidOperationException("Room is not found");
            return new RoomInfoResponseDto()
            {
                BranchId = string.Empty,
            };
        }

        return new RoomInfoResponseDto
        {
            RoomNum = room.RoomNumber,
            Space = room.Space,
            Temperature = room.Temperature.ToString(),
            Capacity = room.Capacity,
            BranchId = room.BranchId,
        };
    }
}