namespace FitmoRE.Application.Services
{
    using FitmoRE.Application.Models.Entities;
    using FitmoRE.Application.Models.Entities.Repositories;

    public interface IGymRoomService
    {
        GymRoom GetRoomById(int roomId);
    }

    public class GymRoomService : IGymRoomService
    {
        private readonly IGymRoomRepository _gymRoomRepository;

        public GymRoomService(IGymRoomRepository gymRoomRepository)
        {
            _gymRoomRepository = gymRoomRepository;
        }

        public GymRoom GetRoomById(int roomId)
        {
            return _gymRoomRepository.GetById(roomId);
        }
    }
}