using FitmoRE.Application.DTO;
using MediatR;

namespace FitmoRE.Application.Events.Commands;

public class RegisterUserCommand : IRequest<UserRegistrationResponseDto>
{
    public UserRegistrationDto RegistrationDto { get; }

    public RegisterUserCommand(UserRegistrationDto registrationDto)
    {
        RegistrationDto = registrationDto;
    }
}