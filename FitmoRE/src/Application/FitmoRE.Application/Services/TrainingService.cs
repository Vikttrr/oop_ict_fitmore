using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Models;
using FitmoRE.Application.Repositories;
using FitmoRE.Application.Services.Interfaces;

namespace FitmoRE.Application.Services;
public class TrainingService : ITrainingService
{
    private readonly ITrainingRepository _trainingRepository;
    private readonly ITrainingRegistrationRepository _trainingRegistrationRepository;

    public TrainingService(ITrainingRepository trainingRepository, ITrainingRegistrationRepository trainingRegistrationRepository)
    {
        _trainingRepository = trainingRepository;
        _trainingRegistrationRepository = trainingRegistrationRepository;
    }

    public AddTrainingResponseDto AddTraining(AddTrainingDto trainingDto)
    {
        string id = new Random().Next().ToString();
        var trainingSession = new TrainingSessionModel(
            id,
            trainingDto.RoomId,
            trainingDto.EmployeeId,
            trainingDto.ParticipantsNumber,
            trainingDto.StartTime,
            trainingDto.EndTime,
            trainingDto.Description);
        string newId = _trainingRepository.Add(trainingSession);

        return new AddTrainingResponseDto
        {
            TrainingId = newId,
        };
    }

    public TrainingInfoResponseDto GetTrainingInfo(string trainingId)
    {
        TrainingSessionModel? training = _trainingRepository.GetById(trainingId);
        if (training == null)
        {
            return new TrainingInfoResponseDto()
            {
                EmployeeId = string.Empty,
            };
        }

        return new TrainingInfoResponseDto
        {
            RoomId = training.RoomId,
            EmployeeId = training.EmployeeId,
            ParticipantsNumber = training.NumberOfParticipants,
            StartTime = training.StartTime,
            EndTime = training.EndTime,
            Description = training.Description,
        };
    }

    public TrainingSignupResponseDto SignupForTraining(TrainingSignupDto signupDto)
    {
        string id = new Random().Next().ToString();
        var trainingRegistration = new TrainingRegistrationModel(
            id,
            signupDto.TrainingId,
            signupDto.ClientId,
            true);

            // signupDto.DateTime,
        _trainingRegistrationRepository.Add(trainingRegistration);

        return new TrainingSignupResponseDto
        {
            IsConfirmed = true,
        };
    }
}
