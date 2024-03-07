using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Entities;
using FitmoRE.Application.Models.Entities.Repositories;

namespace FitmoRE.Application.Services
{
    public interface IRoomService
    {
        RoomInfoResponseDto GetRoomInfo(int roomId);
    }

    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public RoomInfoResponseDto GetRoomInfo(int roomId)
        {
            var room = _roomRepository.GetById(roomId);
            if (room == null)
            {
                throw new InvalidOperationException("Room is not found");
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
}