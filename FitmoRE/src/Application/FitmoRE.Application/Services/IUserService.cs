namespace FitmoRE.Application.Services;

using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Entities;
using FitmoRE.Application.Models.Entities.Repositories;

public interface IUserService
{
    void RegisterUser(UserRegistrationDto registrationDto);

    UserInfoResponseDto GetUserInfo(int clientId);

    UserAuthResponseDto AuthenticateUser(UserAuthDto authDto);
}

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void RegisterUser(UserRegistrationDto registrationDto)
    {
        var client = new Client(
            0,
            registrationDto.FullName,
            registrationDto.BirthDate,
            registrationDto.Phone,
            registrationDto.Email,
            string.Empty,
            true);
        _userRepository.Add(client);
    }

    public UserInfoResponseDto GetUserInfo(int clientId)
    {
        var client = _userRepository.GetById(clientId);
        if (client == null)
        {
            throw new InvalidOperationException("User is not found");
        }

        return new UserInfoResponseDto
        {
            FullName = client.FullName,
            BirthDate = client.DateOfBirth,
            Phone = client.PhoneNumber,
            Email = client.Email,
            Address = client.Address,
            SubscriptionType = "basic",
            IsActive = client.IsActive,
        };
    }

    public UserAuthResponseDto AuthenticateUser(UserAuthDto authDto)
    {
        var client = _userRepository.FindByPhoneAndClientId(authDto.Phone, authDto.ClientId);

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
