using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Entities;
using FitmoRE.Application.Repositories;
using FitmoRE.Infrastructure.Persistence.Contexts;

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

        public string Add(GymRoom room)
        {
            FitmoRE.Infrastructure.Persistence.Entities.GymRoom entity = MapGymRoomToEntity(room);
            _dbContext.GymRooms?.Add(entity);
            _dbContext.SaveChanges();
            return entity.RoomId;
        }

        public GymRoom GetById(string roomId)
        {
            FitmoRE.Infrastructure.Persistence.Entities.GymRoom? entity = _dbContext.GymRooms?.FirstOrDefault(r => r.RoomId == roomId);
            return (entity != null ? MapEntityToGymRoom(entity) : null) ?? new GymRoom();
        }

        public RoomInfoResponseDto? Update(GymRoom room)
        {
            FitmoRE.Infrastructure.Persistence.Entities.GymRoom? existingEntity = _dbContext.GymRooms?.FirstOrDefault(r => r.RoomId == room.RoomId);
            if (existingEntity != null)
            {
                existingEntity.RoomNumber = room.RoomNumber;
                existingEntity.Space = room.Space;
                existingEntity.Temperature = room.Temperature;
                existingEntity.Capacity = room.Capacity;
                existingEntity.BranchId = room.BranchId;

                _dbContext.SaveChanges();

                return MapEntityToRoomInfoResponseDto(existingEntity);
            }

            return null;
        }

        public RoomInfoDto? Delete(string roomId)
        {
            FitmoRE.Infrastructure.Persistence.Entities.GymRoom? entity = _dbContext.GymRooms?.FirstOrDefault(r => r.RoomId == roomId);
            if (entity != null)
            {
                _dbContext.GymRooms?.Remove(entity);
                _dbContext.SaveChanges();
                return MapEntityToRoomInfoDto(entity);
            }

            return null;
        }

        private GymRoom MapEntityToGymRoom(FitmoRE.Infrastructure.Persistence.Entities.GymRoom entity)
        {
            return new GymRoom(
                entity.RoomId,
                entity.RoomNumber,
                entity.Space ?? 0,
                entity.Temperature,
                entity.Capacity ?? 0,
                "0");
        }

        private RoomInfoResponseDto? MapEntityToRoomInfoResponseDto(FitmoRE.Infrastructure.Persistence.Entities.GymRoom entity)
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

        private RoomInfoDto? MapEntityToRoomInfoDto(FitmoRE.Infrastructure.Persistence.Entities.GymRoom entity)
        {
            return new RoomInfoDto
            {
                RoomId = entity.RoomId,
            };
        }

        private FitmoRE.Infrastructure.Persistence.Entities.GymRoom MapGymRoomToEntity(GymRoom room)
        {
            return new FitmoRE.Infrastructure.Persistence.Entities.GymRoom
            {
                RoomId = room.RoomId,
                RoomNumber = room.RoomNumber,
                Space = room.Space,
                Temperature = room.Temperature,
                Capacity = room.Capacity,
            };
        }
    }
