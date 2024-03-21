using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Models;

namespace FitmoRE.Application.Repositories;
public interface ITrainingRegistrationRepository
{
    string Add(TrainingRegistrationModel fitnessService);

    TrainingSignupDto? GetById(string registrationId);

    TrainingSignupResponseDto Update(FitnessServiceModel fitnessServiceModel);

    TrainingSignupDto? Delete(string registrationId);

    IEnumerable<TrainingSignupDto?> GetAllByTrainingId(string trainingId);

    IEnumerable<TrainingSignupDto?> GetAllByClientId(string clientId);
}