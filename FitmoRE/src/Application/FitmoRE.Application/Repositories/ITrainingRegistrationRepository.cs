using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Entities;

namespace FitmoRE.Application.Repositories;
public interface ITrainingRegistrationRepository
{
    string Add(TrainingRegistration fitnessService);

    TrainingSignupDto GetById(string registrationId);

    TrainingSignupResponseDto Update(FitnessService fitnessService);

    TrainingSignupDto Delete(string registrationId);

    IEnumerable<TrainingSignupDto> GetAllByTrainingId(string trainingId);

    IEnumerable<TrainingSignupDto> GetAllByClientId(string clientId);
}