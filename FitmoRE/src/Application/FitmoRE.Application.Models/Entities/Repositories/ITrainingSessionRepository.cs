namespace FitmoRE.Application.Models.Entities.Repositories;

public interface ITrainingSessionRepository
{
    void AddSession(TrainingSession session);

    void AddRegistration(TrainingRegistration registration);

    TrainingSession GetSessionById(int sessionId);

    IEnumerable<TrainingSession> GetAllSessions();

    IEnumerable<TrainingRegistration> GetRegistrationsForClient(int clientId);

    void UpdateSession(TrainingSession session);

    void RemoveSession(TrainingSession session);
}