using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Entities;
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
        var trainingSession = new TrainingSession(
            string.Empty,
            trainingDto.RoomId,
            trainingDto.EmployeeId,
            trainingDto.ParticipantsNumber,
            trainingDto.StartTime,
            trainingDto.EndTime,
            trainingDto.Description);
        string id = _trainingRepository.Add(trainingSession);

        return new AddTrainingResponseDto
        {
            TrainingId = id,
        };
    }

    public TrainingInfoResponseDto GetTrainingInfo(string trainingId)
    {
        TrainingSession? training = _trainingRepository.GetById(trainingId);
        if (training == null)
        {
            // throw new InvalidOperationException("Training session is not found");
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
        var trainingRegistration = new TrainingRegistration(
            string.Empty,
            signupDto.TrainingId,
            signupDto.ClientId,
            signupDto.DateTime,
            true);
        _trainingRegistrationRepository.Add(trainingRegistration);

        return new TrainingSignupResponseDto
        {
            IsConfirmed = true,
        };
    }
}
