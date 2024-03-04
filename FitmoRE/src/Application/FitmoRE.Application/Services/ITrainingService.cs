namespace FitmoRE.Application.Services
{
    using FitmoRE.Application.DTO;
    using FitmoRE.Application.Models.Entities;
    using FitmoRE.Application.Repositories;

    public interface ITrainingService
    {
        TrainingSession AddTraining(TrainingDto dto);

        TrainingSession GetTrainingById(int trainingId);
    }

    public class TrainingService : ITrainingService
    {
        private readonly ITrainingRepository _trainingRepository;

        public TrainingService(ITrainingRepository trainingRepository)
        {
            _trainingRepository = trainingRepository;
        }

        public TrainingSession AddTraining(TrainingDto dto)
        {
            var trainingSession = new TrainingSession(
                0,
                dto.RoomId,
                dto.EmployeeId,
                dto.TrainerId,
                dto.NumberOfParticipants,
                dto.StartTime,
                dto.EndTime,
                dto.Description);

            _trainingRepository.Add(trainingSession);
            _trainingRepository.SaveChanges();

            return trainingSession;
        }

        public TrainingSession GetTrainingById(int trainingId)
        {
            var trainingSession = _trainingRepository.GetById(trainingId);
            if (trainingSession == null)
            {
                throw new KeyNotFoundException("Training session not found with ID " + trainingId);
            }

            return trainingSession;
        }
    }
}