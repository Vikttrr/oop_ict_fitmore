using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Entities;

namespace FitmoRE.Application.Repositories
{
    public interface IUserRepository
    {
        UserRegistrationResponseDto Add(Client userRegistrationDto);

        UserInfoResponseDto GetById(int clientId);

        UserAuthResponseDto FindByPhoneAndClientId(UserAuthDto userAuthDto);

        UserInfoResponseDto Update(UserInfoDto userInfoDto);

        UserInfoDto Delete(int clientId);

        IEnumerable<UserInfoResponseDto> GetAll();
    }
}