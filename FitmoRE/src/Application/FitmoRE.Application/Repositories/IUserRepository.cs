using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Entities;

namespace FitmoRE.Application.Repositories;
public interface IUserRepository
{
    string Add(Client client);

    Client GetById(string clientId);

    Client FindByPhoneAndClientId(string id, string phone);

    UserInfoResponseDto Update(Client client);

    UserInfoDto Delete(int clientId);

    IEnumerable<UserInfoResponseDto> GetAll();
}