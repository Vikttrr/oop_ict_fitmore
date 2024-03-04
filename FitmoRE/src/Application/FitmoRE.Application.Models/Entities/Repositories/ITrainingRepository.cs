namespace FitmoRE.Application.Repositories
{
    public interface ITrainingRepository
    {
        void Add(TrainingSession trainingSession);

        void SaveChanges();

        TrainingSession GetById(int trainingId);

        IEnumerable<TrainingSession> GetAll();

        void Update(TrainingSession trainingSession);

        void Delete(int trainingId);
    }
}