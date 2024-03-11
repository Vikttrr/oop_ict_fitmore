namespace FitmoRE.Application.Repositories;

using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Entities;

public interface ITrainingRegistrationRepository
{
    string Add(TrainingRegistration trainingSignupDto);

    TrainingSignupDto GetById(string registrationId);

    TrainingSignupResponseDto Update(TrainingSignupDto trainingSignupDto);

    TrainingSignupDto Delete(string registrationId);

    IEnumerable<TrainingSignupDto> GetAllByTrainingId(string trainingId);

    IEnumerable<TrainingSignupDto> GetAllByClientId(string clientId);
}