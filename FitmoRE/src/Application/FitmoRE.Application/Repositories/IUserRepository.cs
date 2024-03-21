using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Models;

namespace FitmoRE.Application.Repositories;
public interface IUserRepository
{
    string Add(ClientModel clientModel);

    ClientModel GetById(string clientId);

    UserInfoResponseDto? Update(ClientModel clientModel);

    UserInfoDto? Delete(string clientId);

    ClientModel? FindByPhoneAndClientId(string clientId, string phone);

    IEnumerable<UserInfoResponseDto?> GetAll();
}