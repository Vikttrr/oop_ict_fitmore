using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Models;
using FitmoRE.Application.Repositories;
using FitmoRE.Infrastructure.Persistence.Contexts;
using FitmoRE.Infrastructure.Persistence.Entities;

namespace FitmoRE.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public string Add(ClientModel clientModel)
    {
        Client entity = MapClientToEntity(clientModel);
        _dbContext.Clients?.Add(entity);
        _dbContext.SaveChanges();
        return entity.Clientid;
    }

    public ClientModel GetById(string clientId)
    {
        Client? entity = _dbContext.Clients?.FirstOrDefault(c => c.Clientid == clientId);
        return (entity != null ? MapEntityToClient(entity) : null) ?? new ClientModel();
    }

    public UserInfoResponseDto? Update(ClientModel clientModel)
    {
        Client? existingEntity = _dbContext.Clients?.FirstOrDefault(c => c.Clientid == clientModel.ClientId);
        if (existingEntity != null)
        {
            existingEntity.Fullname = clientModel.FullName;
            existingEntity.Dateofbirth = clientModel.DateOfBirth;
            existingEntity.Phonenumber = clientModel.PhoneNumber;
            existingEntity.Email = clientModel.Email;
            existingEntity.Isactive = clientModel.IsActive;

            _dbContext.SaveChanges();

            return MapEntityToUserInfoResponseDto(existingEntity);
        }

        return null;
    }

    public UserInfoDto? Delete(string clientId)
    {
        Client? entity = _dbContext.Clients?.FirstOrDefault(c => c.Clientid == clientId);
        if (entity != null)
        {
            _dbContext.Clients?.Remove(entity);
            _dbContext.SaveChanges();
            return MapEntityToUserInfoDto(entity);
        }

        return null;
    }

    public ClientModel? FindByPhoneAndClientId(string clientId, string phone)
    {
        Client? entity = _dbContext.Clients?.FirstOrDefault(c => c.Clientid == clientId && c.Phonenumber == phone);
        return entity != null ? MapEntityToClient(entity) : null;
    }

    public IEnumerable<UserInfoResponseDto?> GetAll()
    {
        var entities = _dbContext.Clients?.ToList();
        return entities?.Select(MapEntityToUserInfoResponseDto) ?? Array.Empty<UserInfoResponseDto?>();
    }

    private ClientModel MapEntityToClient(Client entity)
    {
        return new ClientModel(
            entity.Clientid,
            entity.Fullname,
            entity.Dateofbirth,
            entity.Phonenumber,
            entity.Email,
            entity.Isactive ?? false);
    }

    private Client MapClientToEntity(ClientModel model)
    {
        return new Client
        {
            Clientid = model.ClientId,
            Fullname = model.FullName,
            Dateofbirth = model.DateOfBirth,
            Phonenumber = model.PhoneNumber,
            Email = model.Email,
            Isactive = model.IsActive,
        };
    }

    private UserInfoResponseDto? MapEntityToUserInfoResponseDto(Client entity)
    {
        return new UserInfoResponseDto
        {
            ClientId = entity.Clientid,
            FullName = entity.Fullname,
            BirthDate = entity.Dateofbirth,
            Phone = entity.Phonenumber,
            Email = entity.Email,
            IsActive = entity.Isactive,
        };
    }

    private UserInfoDto MapEntityToUserInfoDto(Client entity)
    {
        return new UserInfoDto
        {
            ClientId = entity.Clientid,
        };
    }
}
