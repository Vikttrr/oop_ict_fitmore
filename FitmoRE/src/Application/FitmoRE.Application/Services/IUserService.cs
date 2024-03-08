using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Entities;
using FitmoRE.Application.Repositories;

namespace FitmoRE.Application.Services;
public interface IUserService
{
    UserRegistrationResponseDto RegisterUser(UserRegistrationDto registrationDto);

    UserInfoResponseDto GetUserInfo(string clientId);

    UserAuthResponseDto AuthenticateUser(UserAuthDto authDto);
}

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
        _userRepository.Add(client);

        return new UserRegistrationResponseDto
        {
            UserId = client.ClientId.ToString(),
        };
    }

    public UserInfoResponseDto GetUserInfo(string clientId)
    {
        throw new NotImplementedException();
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
            BirthDate = client.BirthDate,
            Phone = client.Phone,
            Email = client.Email,
            Address = client.Address,
            SubscriptionType = "basic",
            IsActive = client.IsActive,
        };
    }

    public UserAuthResponseDto AuthenticateUser(UserAuthDto authDto)
    {
        var client = _userRepository.FindByPhoneAndClientId(authDto);

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
