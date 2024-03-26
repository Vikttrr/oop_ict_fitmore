using FitmoRE.Application.DTO;
using MediatR;

namespace FitmoRE.Application.Events.Commands;

public class SignupForTrainingCommand : IRequest<TrainingSignupResponseDto>
{
    public TrainingSignupDto SignupDto { get; }

    public SignupForTrainingCommand(TrainingSignupDto signupDto)
    {
        SignupDto = signupDto;
    }
}