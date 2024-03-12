using FitmoRE.Application.DTO;
using FitmoRE.Application.Repositories;

namespace FitmoRE.Application.Services;
public interface IRoomService
{
    RoomInfoResponseDto GetRoomInfo(RoomInfoDto roomId);
}

public class RoomService : IRoomService
{
    private readonly IRoomRepository _roomRepository;

    public RoomService(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public RoomInfoResponseDto GetRoomInfo(RoomInfoDto roomId)
    {
        var room = _roomRepository.GetById(roomId.RoomId);
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