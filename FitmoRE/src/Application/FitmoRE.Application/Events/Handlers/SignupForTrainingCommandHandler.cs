using FitmoRE.Application.DTO;
using FitmoRE.Application.Events.Commands;
using FitmoRE.Application.Models.Models;
using FitmoRE.Application.Repositories;
using MediatR;

namespace FitmoRE.Application.Events.Handlers;

public class SignupForTrainingCommandHandler : IRequestHandler<SignupForTrainingCommand, TrainingSignupResponseDto>
{
    private readonly ITrainingRegistrationRepository _trainingRegistrationRepository;

    public SignupForTrainingCommandHandler(ITrainingRegistrationRepository trainingRegistrationRepository)
    {
        _trainingRegistrationRepository = trainingRegistrationRepository;
    }

    public Task<TrainingSignupResponseDto> Handle(SignupForTrainingCommand request, CancellationToken cancellationToken)
    {
        string id = new Random().Next().ToString();
        var trainingRegistration = new TrainingRegistrationModel(
            id,
            request.SignupDto.TrainingId,
            request.SignupDto.ClientId,
            true);

        _trainingRegistrationRepository.Add(trainingRegistration);

        var responseDto = new TrainingSignupResponseDto
        {
            IsConfirmed = true,
        };

        return Task.FromResult(responseDto);
    }
}