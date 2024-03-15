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

    public UserRegistrationResponseDto RegisterUser(UserRegistrationDto registrationDto)
    {
        var client = new Client(
            string.Empty,
            registrationDto.FullName,
            DateTime.Parse(registrationDto.BirthDate).ToString(),
            registrationDto.Phone,
            registrationDto.Email,
            string.Empty,
            true);
        string id = _userRepository.Add(client);

        return new UserRegistrationResponseDto
        {
            UserId = id,
        };
    }

    public UserInfoResponseDto GetUserInfo(string clientId)
    {
        Client client = _userRepository.GetById(clientId);
        if (client == null)
        {
            // throw new InvalidOperationException("User is not found");
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
            Address = client.Address,

            // SubscriptionType = "basic",
            IsActive = client.IsActive,
        };
    }

    public UserAuthResponseDto AuthenticateUser(UserAuthDto authDto)
    {
        Client? client = _userRepository.FindByPhoneAndClientId(authDto.ClientId, authDto.Phone);

        if (client == null)
        {
            throw new UnauthorizedAccessException("Authorization failed: User not found or incorrect credentials.");
        }

        return new UserAuthResponseDto
        {
            Message = "all good, signed in",
        };
    }
}
