using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Entities;
using FitmoRE.Application.Repositories;
using FitmoRE.Infrastructure.Persistence.Contexts;

namespace FitmoRE.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public string Add(Client client)
    {
        FitmoRE.Infrastructure.Persistence.Entities.Client entity = MapClientToEntity(client);
        _dbContext.Clients?.Add(entity);
        _dbContext.SaveChanges();
        return entity.Clientid;
    }

    public Client GetById(string clientId)
    {
        FitmoRE.Infrastructure.Persistence.Entities.Client? entity = _dbContext.Clients?.FirstOrDefault(c => c.Clientid == clientId);
        return (entity != null ? MapEntityToClient(entity) : null) ?? new Client();
    }

    public UserInfoResponseDto? Update(Client client)
    {
        FitmoRE.Infrastructure.Persistence.Entities.Client? existingEntity = _dbContext.Clients?.FirstOrDefault(c => c.Clientid == client.ClientId);
        if (existingEntity != null)
        {
            existingEntity.Fullname = client.FullName;
            existingEntity.Dateofbirth = client.DateOfBirth;
            existingEntity.Phonenumber = client.PhoneNumber;
            existingEntity.Email = client.Email;
            existingEntity.Isactive = client.IsActive;

            _dbContext.SaveChanges();

            return MapEntityToUserInfoResponseDto(existingEntity);
        }

        return null;
    }

    public UserInfoDto? Delete(string clientId)
    {
        FitmoRE.Infrastructure.Persistence.Entities.Client? entity = _dbContext.Clients?.FirstOrDefault(c => c.Clientid == clientId);
        if (entity != null)
        {
            _dbContext.Clients?.Remove(entity);
            _dbContext.SaveChanges();
            return MapEntityToUserInfoDto(entity);
        }

        return null;
    }

    public Client? FindByPhoneAndClientId(string clientId, string phone)
    {
        FitmoRE.Infrastructure.Persistence.Entities.Client? entity = _dbContext.Clients?.FirstOrDefault(c => c.Clientid == clientId && c.Phonenumber == phone);
        return entity != null ? MapEntityToClient(entity) : null;
    }

    public IEnumerable<UserInfoResponseDto?> GetAll()
    {
        var entities = _dbContext.Clients?.ToList();
        return entities?.Select(MapEntityToUserInfoResponseDto) ?? Array.Empty<UserInfoResponseDto?>();
    }

    private Client MapEntityToClient(FitmoRE.Infrastructure.Persistence.Entities.Client entity)
    {
        return new Client(
            entity.Clientid,
            entity.Fullname,
            entity.Dateofbirth,
            entity.Phonenumber,
            entity.Email,
            entity.Isactive ?? false);
    }

    private FitmoRE.Infrastructure.Persistence.Entities.Client MapClientToEntity(Client model)
    {
        return new FitmoRE.Infrastructure.Persistence.Entities.Client
        {
            Clientid = model.ClientId,
            Fullname = model.FullName,
            Dateofbirth = model.DateOfBirth,
            Phonenumber = model.PhoneNumber,
            Email = model.Email,
            Isactive = model.IsActive,
        };
    }

    private UserInfoResponseDto? MapEntityToUserInfoResponseDto(FitmoRE.Infrastructure.Persistence.Entities.Client entity)
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

    private UserInfoDto MapEntityToUserInfoDto(FitmoRE.Infrastructure.Persistence.Entities.Client entity)
    {
        return new UserInfoDto
        {
            ClientId = entity.Clientid,
        };
    }
}
