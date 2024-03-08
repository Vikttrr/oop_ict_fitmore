using FitmoRE.Application.DTO;
using FitmoRE.Application.Repositories;

namespace FitmoRE.Application.Services
{
    public interface IRoomService
    {
        RoomInfoResponseDto GetRoomInfo(string roomId);
    }

    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public RoomInfoResponseDto GetRoomInfo(string roomId)
        {
            var room = _roomRepository.GetById(roomId.ToString());
            if (room == null)
            {
                throw new InvalidOperationException("Room is not found");
            }

            return new RoomInfoResponseDto
            {
                RoomNum = room.RoomNum,
                Space = room.Space,
                Temperature = room.Temperature.ToString(),
                Capacity = room.Capacity,
                BranchId = room.BranchId,
            };
        }
    }
}