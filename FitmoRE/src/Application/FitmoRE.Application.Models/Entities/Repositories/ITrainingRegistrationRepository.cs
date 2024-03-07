namespace FitmoRE.Application.Models.Entities.Repositories
{
    public interface ITrainingRegistrationRepository
    {
        void Add(TrainingRegistration trainingRegistration);

        TrainingRegistration GetById(int registrationId);

        void Update(TrainingRegistration trainingRegistration);

        void Delete(int registrationId);

        IEnumerable<TrainingRegistration> GetAllByTrainingId(int trainingId);

        IEnumerable<TrainingRegistration> GetAllByClientId(int clientId);
    }
}