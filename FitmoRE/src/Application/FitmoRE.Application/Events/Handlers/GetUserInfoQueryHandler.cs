using FitmoRE.Application.DTO;
using FitmoRE.Application.Events.Queries;
using FitmoRE.Application.Models.Models;
using FitmoRE.Application.Repositories;
using MediatR;

namespace FitmoRE.Application.Events.Handlers;

public class GetUserInfoQueryHandler : IRequestHandler<GetUserInfoQuery, UserInfoResponseDto>
{
    private readonly IUserRepository _userRepository;

    public GetUserInfoQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<UserInfoResponseDto> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
    {
        ClientModel clientModel = _userRepository.GetById(request.ClientId);
        if (string.IsNullOrEmpty(clientModel.ClientId))
        {
            return Task.FromResult(new UserInfoResponseDto
            {
                FullName = string.Empty,
            });
        }

        var responseDto = new UserInfoResponseDto
        {
            FullName = clientModel.FullName,
            BirthDate = clientModel.DateOfBirth,
            Phone = clientModel.PhoneNumber,
            Email = clientModel.Email,
            IsActive = clientModel.IsActive,
            ClientId = clientModel.ClientId,
        };

        return Task.FromResult(responseDto);
    }
}