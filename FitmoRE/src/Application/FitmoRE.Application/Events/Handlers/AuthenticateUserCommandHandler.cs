using FitmoRE.Application.DTO;
using FitmoRE.Application.Events.Commands;
using FitmoRE.Application.Models.Models;
using FitmoRE.Application.Repositories;
using MediatR;

namespace FitmoRE.Application.Events.Handlers;

public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, UserAuthResponseDto>
{
    private readonly IUserRepository _userRepository;

    public AuthenticateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<UserAuthResponseDto> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
    {
        ClientModel? client = _userRepository.FindByPhoneAndClientId(request.AuthDto.ClientId, request.AuthDto.Phone);

        if (client == null)
        {
            return Task.FromResult(new UserAuthResponseDto { Message = string.Empty, });
        }

        return Task.FromResult(new UserAuthResponseDto
        {
            Message = "all good, signed in",
        });
    }
}