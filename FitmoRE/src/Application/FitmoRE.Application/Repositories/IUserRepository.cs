namespace FitmoRE.Application.Repositories;

using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Entities;

public interface IUserRepository
{
    string Add(Client client);

    Client GetById(string clientId);

    Client FindByPhoneAndClientId(string id, string phone);

    UserInfoResponseDto Update(UserInfoDto userInfoDto);

    UserInfoDto Delete(int clientId);

    IEnumerable<UserInfoResponseDto> GetAll();
}