using FitmoRE.Application.DTO;

namespace FitmoRE.Application.Services.Interfaces;
public interface ITrainingService
{
    AddTrainingResponseDto AddTraining(AddTrainingDto trainingDto);

    TrainingInfoResponseDto GetTrainingInfo(string trainingId);

    TrainingSignupResponseDto SignupForTraining(TrainingSignupDto signupDto);
}