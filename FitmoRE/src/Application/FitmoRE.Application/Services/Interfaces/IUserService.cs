using FitmoRE.Application.DTO;

namespace FitmoRE.Application.Services.Interfaces;
public interface IUserService
{
    UserRegistrationResponseDto RegisterUser(UserRegistrationDto registrationDto);

    UserInfoResponseDto GetUserInfo(string clientId);

    UserAuthResponseDto AuthenticateUser(UserAuthDto authDto);
}