using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Models;
using FitmoRE.Application.Repositories;
using FitmoRE.Infrastructure.Persistence.Contexts;
using FitmoRE.Infrastructure.Persistence.Entities;

namespace FitmoRE.Infrastructure.Persistence.Repositories;

public class RoomRepository : IRoomRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public RoomRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<RoomInfoResponseDto?> GetAll()
        {
            var employeeEntities = _dbContext.GymRooms?.ToList();
            return employeeEntities?.Select(MapEntityToRoomInfoResponseDto) ?? Array.Empty<RoomInfoResponseDto>();
        }

        public string Add(GymRoomModel roomModel)
        {
            GymRoom entity = MapGymRoomToEntity(roomModel);
            _dbContext.GymRooms?.Add(entity);
            _dbContext.SaveChanges();
            return entity.RoomId;
        }

        public GymRoomModel GetById(string roomId)
        {
            GymRoom? entity = _dbContext.GymRooms?.FirstOrDefault(r => r.RoomId == roomId);
            return (entity != null ? MapEntityToGymRoom(entity) : null) ?? new GymRoomModel();
        }

        public RoomInfoResponseDto? Update(GymRoomModel roomModel)
        {
            GymRoom? existingEntity = _dbContext.GymRooms?.FirstOrDefault(r => r.RoomId == roomModel.RoomId);
            if (existingEntity != null)
            {
                existingEntity.RoomNumber = roomModel.RoomNumber;
                existingEntity.Space = roomModel.Space;
                existingEntity.Temperature = roomModel.Temperature;
                existingEntity.Capacity = roomModel.Capacity;
                existingEntity.BranchId = roomModel.BranchId;

                _dbContext.SaveChanges();

                return MapEntityToRoomInfoResponseDto(existingEntity);
            }

            return null;
        }

        public RoomInfoDto? Delete(string roomId)
        {
            GymRoom? entity = _dbContext.GymRooms?.FirstOrDefault(r => r.RoomId == roomId);
            if (entity != null)
            {
                _dbContext.GymRooms?.Remove(entity);
                _dbContext.SaveChanges();
                return MapEntityToRoomInfoDto(entity);
            }

            return null;
        }

        private GymRoomModel MapEntityToGymRoom(GymRoom entity)
        {
            return new GymRoomModel(
                entity.RoomId,
                entity.RoomNumber,
                entity.Space ?? 0,
                entity.Temperature,
                entity.Capacity ?? 0,
                "0");
        }

        private RoomInfoResponseDto? MapEntityToRoomInfoResponseDto(GymRoom entity)
        {
            return new RoomInfoResponseDto
            {
                RoomNum = entity.RoomNumber,
                Space = entity.Space,
                Temperature = entity.Temperature,
                Capacity = entity.Capacity,
                BranchId = entity.BranchId,
            };
        }

        private RoomInfoDto? MapEntityToRoomInfoDto(GymRoom entity)
        {
            return new RoomInfoDto
            {
                RoomId = entity.RoomId,
            };
        }

        private GymRoom MapGymRoomToEntity(GymRoomModel roomModel)
        {
            return new GymRoom
            {
                RoomId = roomModel.RoomId,
                RoomNumber = roomModel.RoomNumber,
                Space = roomModel.Space,
                Temperature = roomModel.Temperature,
                Capacity = roomModel.Capacity,
            };
        }
    }
