using FitmoRE.Application.DTO;
using FitmoRE.Application.Events.Commands;
using FitmoRE.Application.Models.Models;
using FitmoRE.Application.Repositories;
using MediatR;

namespace FitmoRE.Application.Events.Handlers;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, UserRegistrationResponseDto>
{
    private readonly IUserRepository _userRepository;

    public RegisterUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<UserRegistrationResponseDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        string id = new Random().Next().ToString();
        var client = new ClientModel(
            id,
            request.RegistrationDto.FullName,
            request.RegistrationDto.BirthDate,
            request.RegistrationDto.Phone,
            request.RegistrationDto.Email,
            true);
        string newId = _userRepository.Add(client);

        var responseDto = new UserRegistrationResponseDto
        {
            UserId = newId,
        };

        return Task.FromResult(responseDto);
    }
}