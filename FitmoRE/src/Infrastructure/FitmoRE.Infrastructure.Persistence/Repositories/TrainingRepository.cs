using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Models;
using FitmoRE.Application.Repositories;
using FitmoRE.Infrastructure.Persistence.Contexts;
using FitmoRE.Infrastructure.Persistence.Entities;

namespace FitmoRE.Infrastructure.Persistence.Repositories;
    public class TrainingRepository : ITrainingRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TrainingRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string Add(TrainingSessionModel trainingSessionModel)
        {
            TrainingSession entity = MapTrainingToEntity(trainingSessionModel);
            _dbContext.TrainingSessions?.Add(entity);
            _dbContext.SaveChanges();
            return entity.Trainingid;
        }

        public TrainingSessionModel? GetById(string trainingId)
        {
            TrainingSession? entity = _dbContext.TrainingSessions?.FirstOrDefault(t => t.Trainingid == trainingId);
            return entity != null ? MapEntityToTraining(entity) : null;
        }

        public TrainingInfoResponseDto? Update(TrainingSessionModel trainingSessionModel)
        {
            TrainingSession? existingEntity = _dbContext.TrainingSessions?.FirstOrDefault(t => t.Trainingid == trainingSessionModel.TrainingId);
            if (existingEntity != null)
            {
                existingEntity.Roomid = trainingSessionModel.RoomId;
                existingEntity.Employeeid = trainingSessionModel.EmployeeId;
                existingEntity.Numberofparticipants = trainingSessionModel.NumberOfParticipants;
                existingEntity.Starttime = trainingSessionModel.StartTime;
                existingEntity.Endtime = trainingSessionModel.EndTime;
                existingEntity.Description = trainingSessionModel.Description;

                _dbContext.SaveChanges();

                return MapEntityToTrainingInfoResponseDto(existingEntity);
            }

            return null;
        }

        public AddTrainingDto? Delete(string trainingId)
        {
            TrainingSession? entity = _dbContext.TrainingSessions?.FirstOrDefault(t => t.Trainingid == trainingId);
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

        private TrainingSessionModel? MapEntityToTraining(TrainingSession entity)
        {
            return new TrainingSessionModel(
                entity.Trainingid,
                entity.Roomid ?? string.Empty,
                entity.Employeeid,
                entity.Numberofparticipants ?? 0,
                entity.Starttime,
                entity.Endtime,
                entity.Description);
        }

        private TrainingSession MapTrainingToEntity(TrainingSessionModel model)
        {
            return new TrainingSession
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

        private TrainingInfoResponseDto MapEntityToTrainingInfoResponseDto(TrainingSession entity)
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

        private AddTrainingDto MapEntityToAddTrainingDto(TrainingSession entity)
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