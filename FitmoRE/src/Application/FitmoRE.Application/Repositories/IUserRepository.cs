using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Entities;

namespace FitmoRE.Application.Repositories;
public interface IUserRepository
{
    string Add(Client client);

    Client GetById(string clientId);

    UserInfoResponseDto? Update(Client client);

    UserInfoDto? Delete(string clientId);

    Client? FindByPhoneAndClientId(string clientId, string phone);

    IEnumerable<UserInfoResponseDto?> GetAll();
}