using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Models;
using FitmoRE.Application.Repositories;
using FitmoRE.Application.Services.Interfaces;

namespace FitmoRE.Application.Services;
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public UserRegistrationResponseDto RegisterUser(UserRegistrationDto registrationDto)
    {
        string id = new Random().Next().ToString();
        var client = new ClientModel(
            id,
            registrationDto.FullName,
            registrationDto.BirthDate,
            registrationDto.Phone,
            registrationDto.Email,
            true);
        string newId = _userRepository.Add(client);

        return new UserRegistrationResponseDto
        {
            UserId = newId,
        };
    }

    public UserInfoResponseDto GetUserInfo(string clientId)
    {
        ClientModel clientModel = _userRepository.GetById(clientId);
        if (string.IsNullOrEmpty(clientModel.ClientId))
        {
            return new UserInfoResponseDto()
            {
                FullName = string.Empty,
            };
        }

        return new UserInfoResponseDto
        {
            FullName = clientModel.FullName,
            BirthDate = clientModel.DateOfBirth,
            Phone = clientModel.PhoneNumber,
            Email = clientModel.Email,
            IsActive = clientModel.IsActive,
            ClientId = clientModel.ClientId,
        };
    }

    public UserAuthResponseDto AuthenticateUser(UserAuthDto authDto)
    {
        ClientModel? client = _userRepository.FindByPhoneAndClientId(authDto.ClientId, authDto.Phone);

        if (client == null)
        {
            return new UserAuthResponseDto { Message = string.Empty, };
        }

        return new UserAuthResponseDto
        {
            Message = "all good, signed in",
        };
    }
}
