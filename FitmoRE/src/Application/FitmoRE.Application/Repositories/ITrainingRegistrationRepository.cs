using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Entities;

namespace FitmoRE.Application.Repositories
{
    public interface ITrainingRegistrationRepository
    {
        TrainingSignupResponseDto Add(TrainingRegistration trainingSignupDto);

        TrainingSignupDto GetById(string registrationId);

        TrainingSignupResponseDto Update(TrainingSignupDto trainingSignupDto);

        TrainingSignupDto Delete(string registrationId);

        IEnumerable<TrainingSignupDto> GetAllByTrainingId(string trainingId);

        IEnumerable<TrainingSignupDto> GetAllByClientId(string clientId);
    }
}