using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Entities;
using FitmoRE.Application.Repositories;
using FitmoRE.Infrastructure.Persistence.Contexts;

namespace FitmoRE.Infrastructure.Persistence.Repositories;
    public class TrainingRepository : ITrainingRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TrainingRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string Add(TrainingSession trainingSession)
        {
            Entities.TrainingSession entity = MapTrainingToEntity(trainingSession);
            _dbContext.TrainingSessions?.Add(entity);
            _dbContext.SaveChanges();
            return entity.Trainingid;
        }

        public TrainingSession? GetById(string trainingId)
        {
            Entities.TrainingSession? entity = _dbContext.TrainingSessions?.FirstOrDefault(t => t.Trainingid == trainingId);
            return entity != null ? MapEntityToTraining(entity) : null;
        }

        public TrainingInfoResponseDto? Update(TrainingSession trainingSession)
        {
            Entities.TrainingSession? existingEntity = _dbContext.TrainingSessions?.FirstOrDefault(t => t.Trainingid == trainingSession.TrainingId);
            if (existingEntity != null)
            {
                existingEntity.Roomid = trainingSession.RoomId;
                existingEntity.Employeeid = trainingSession.EmployeeId;
                existingEntity.Numberofparticipants = trainingSession.NumberOfParticipants;
                existingEntity.Starttime = trainingSession.StartTime;
                existingEntity.Endtime = trainingSession.EndTime;
                existingEntity.Description = trainingSession.Description;

                _dbContext.SaveChanges();

                return MapEntityToTrainingInfoResponseDto(existingEntity);
            }

            return null;
        }

        public AddTrainingDto? Delete(string trainingId)
        {
            Entities.TrainingSession? entity = _dbContext.TrainingSessions?.FirstOrDefault(t => t.Trainingid == trainingId);
            if (entity != null)
            {
                _dbContext.TrainingSessions?.Remove(entity);
                _dbContext.SaveChanges();
                return MapEntityToAddTrainingDto(entity);
            }

            return null;
        }

        public IEnumerable<TrainingInfoResponseDto> GetAll()
        {
            var entities = _dbContext.TrainingSessions?.ToList();
            return (entities ?? throw new InvalidOperationException()).Select(MapEntityToTrainingInfoResponseDto);
        }

        private TrainingSession? MapEntityToTraining(FitmoRE.Infrastructure.Persistence.Entities.TrainingSession entity)
        {
            return new TrainingSession(
                entity.Trainingid,
                entity.Roomid ?? string.Empty,
                entity.Employeeid,
                entity.Numberofparticipants ?? 0,
                entity.Starttime,
                entity.Endtime,
                entity.Description);
        }

        private FitmoRE.Infrastructure.Persistence.Entities.TrainingSession MapTrainingToEntity(TrainingSession model)
        {
            return new FitmoRE.Infrastructure.Persistence.Entities.TrainingSession
            {
                Trainingid = model.TrainingId,
                Roomid = model.RoomId,
                Employeeid = model.EmployeeId,
                Numberofparticipants = model.NumberOfParticipants,
                Starttime = model.StartTime,
                Endtime = model.EndTime,
                Description = model.Description,
            };
        }

        private TrainingInfoResponseDto MapEntityToTrainingInfoResponseDto(FitmoRE.Infrastructure.Persistence.Entities.TrainingSession entity)
        {
            return new TrainingInfoResponseDto
            {
                RoomId = entity.Roomid ?? string.Empty,
                EmployeeId = entity.Employeeid,
                ParticipantsNumber = entity.Numberofparticipants ?? 0,
                StartTime = entity.Starttime,
                EndTime = entity.Endtime,
                Description = entity.Description ?? string.Empty,
            };
        }

        private AddTrainingDto MapEntityToAddTrainingDto(FitmoRE.Infrastructure.Persistence.Entities.TrainingSession entity)
        {
            return new AddTrainingDto
            {
                RoomId = entity.Roomid ?? string.Empty,
                EmployeeId = entity.Employeeid,
                ParticipantsNumber = entity.Numberofparticipants ?? 0,
                StartTime = entity.Starttime,
                EndTime = entity.Endtime,
                Description = entity.Description ?? string.Empty,
            };
        }
    }