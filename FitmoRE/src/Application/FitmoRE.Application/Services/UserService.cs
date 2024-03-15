using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Entities;
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

// DateTime.Parse(registrationDto.BirthDate).ToString(),
    public UserRegistrationResponseDto RegisterUser(UserRegistrationDto registrationDto)
    {
        var id = new Random().Next().ToString();
        var client = new Client(
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
        Client client = _userRepository.GetById(clientId);
        if (string.IsNullOrEmpty(client.ClientId))
        {
            return new UserInfoResponseDto()
            {
                FullName = string.Empty,
            };
        }

        return new UserInfoResponseDto
        {
            FullName = client.FullName,
            BirthDate = client.DateOfBirth,
            Phone = client.PhoneNumber,
            Email = client.Email,
            IsActive = client.IsActive,
            ClientId = client.ClientId,
        };
    }

    public UserAuthResponseDto AuthenticateUser(UserAuthDto authDto)
    {
        Client? client = _userRepository.FindByPhoneAndClientId(authDto.ClientId, authDto.Phone);

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
