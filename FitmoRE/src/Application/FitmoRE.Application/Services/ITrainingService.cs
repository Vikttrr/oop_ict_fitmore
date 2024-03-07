using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Entities;
using FitmoRE.Application.Models.Entities.Repositories;

namespace FitmoRE.Application.Services;
public interface ITrainingService
{
    void AddTraining(AddTrainingDto trainingDto);

    TrainingInfoResponseDto GetTrainingInfo(int trainingId);

    TrainingSignupResponseDto SignupForTraining(TrainingSignupDto signupDto);
}

public class TrainingService : ITrainingService
{
    private readonly ITrainingRepository _trainingRepository;
    private readonly ITrainingRegistrationRepository _trainingRegistrationRepository;

    public TrainingService(ITrainingRepository trainingRepository, ITrainingRegistrationRepository trainingRegistrationRepository)
    {
        _trainingRepository = trainingRepository;
        _trainingRegistrationRepository = trainingRegistrationRepository;
    }

    public void AddTraining(AddTrainingDto trainingDto)
    {
        var trainingSession = new TrainingSession(
            0,
            trainingDto.RoomId,
            trainingDto.EmployeeId,
            0,
            trainingDto.ParticipantsNumber,
            trainingDto.StartTime,
            trainingDto.EndTime,
            trainingDto.Description);
        _trainingRepository.Add(trainingSession);
    }

    public TrainingInfoResponseDto GetTrainingInfo(int trainingId)
    {
        var training = _trainingRepository.GetById(trainingId);
        if (training == null)
        {
            throw new InvalidOperationException("Training session is not found");
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
            0,
            signupDto.TrainingId,
            signupDto.ClientId,
            DateTime.Parse(signupDto.DateTime),
            true);
        _trainingRegistrationRepository.Add(trainingRegistration);

        return new TrainingSignupResponseDto
        {
            IsConfirmed = true,
        };
    }
}
