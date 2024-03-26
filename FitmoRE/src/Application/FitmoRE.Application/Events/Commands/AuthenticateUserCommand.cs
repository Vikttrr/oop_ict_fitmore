using FitmoRE.Application.DTO;
using MediatR;

namespace FitmoRE.Application.Events.Commands;

public class AuthenticateUserCommand : IRequest<UserAuthResponseDto>
{
    public UserAuthDto AuthDto { get; }

    public AuthenticateUserCommand(UserAuthDto authDto)
    {
        AuthDto = authDto;
    }
}