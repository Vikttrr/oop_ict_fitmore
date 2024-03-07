namespace FitmoRE.Application.Models.Entities.Repositories
{
    public interface ITrainingRepository
    {
        void Add(TrainingSession trainingSession);

        TrainingSession GetById(int trainingId);

        void Update(TrainingSession trainingSession);

        void Delete(int trainingId);

        IEnumerable<TrainingSession> GetAll();
    }
}