using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Models;
using FitmoRE.Application.Repositories;
using FitmoRE.Infrastructure.Persistence.Contexts;
using FitmoRE.Infrastructure.Persistence.Entities;

namespace FitmoRE.Infrastructure.Persistence.Repositories;

public class TrainingRegistrationRepository : ITrainingRegistrationRepository
{
    private readonly ApplicationDbContext _dbContext;

    public TrainingRegistrationRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public string Add(TrainingRegistrationModel fitnessService)
    {
        TrainingRegistration entity = MapTrainingRegistrationToEntity(fitnessService);
        _dbContext.TrainingRegistrations?.Add(entity);
        _dbContext.SaveChanges();
        return entity.Registrationid;
    }

    public TrainingSignupDto? GetById(string registrationId)
    {
        TrainingRegistration? entity = _dbContext.TrainingRegistrations?.FirstOrDefault(r => r.Registrationid == registrationId);
        return entity != null ? MapEntityToTrainingSignupDto(entity) : null;
    }

    public TrainingSignupResponseDto Update(FitnessServiceModel fitnessServiceModel)
    {
        throw new NotImplementedException();
    }

    public TrainingSignupResponseDto? Update(TrainingRegistrationModel registrationModel)
    {
        TrainingRegistration? existingEntity = _dbContext.TrainingRegistrations?.FirstOrDefault(r => r.Registrationid == registrationModel.RegistrationId);
        if (existingEntity != null)
        {
            existingEntity.Trainingid = registrationModel.TrainingId;
            existingEntity.Clientid = registrationModel.ClientId;

            // existingEntity.Registrationdate = registration.RegistrationDate;
            existingEntity.Isconfirmed = registrationModel.IsConfirmed;
            _dbContext.SaveChanges();
            return MapEntityToTrainingSignupResponseDto(existingEntity);
        }

        return null;
    }

    public TrainingSignupDto? Delete(string registrationId)
    {
        TrainingRegistration? entity = _dbContext.TrainingRegistrations?.FirstOrDefault(r => r.Registrationid == registrationId);
        if (entity != null)
        {
            _dbContext.TrainingRegistrations?.Remove(entity);
            _dbContext.SaveChanges();
            return MapEntityToTrainingSignupDto(entity);
        }

        return null;
    }

    public IEnumerable<TrainingSignupDto?> GetAllByTrainingId(string trainingId)
    {
        var entities = _dbContext.TrainingRegistrations?.Where(r => r.Trainingid == trainingId).ToList();
        return (entities ?? throw new InvalidOperationException()).Select(MapEntityToTrainingSignupDto);
    }

    public IEnumerable<TrainingSignupDto?> GetAllByClientId(string clientId)
    {
        var entities = _dbContext.TrainingRegistrations?.Where(r => r.Clientid == clientId).ToList();
        return (entities ?? throw new InvalidOperationException()).Select(MapEntityToTrainingSignupDto);
    }

    private TrainingRegistration MapTrainingRegistrationToEntity(TrainingRegistrationModel model)
    {
        return new TrainingRegistration
        {
            Registrationid = model.RegistrationId,
            Trainingid = model.TrainingId,
            Clientid = model.ClientId,

            // Registrationdate = model.RegistrationDate,
            Isconfirmed = model.IsConfirmed,
        };
    }

    private TrainingSignupDto? MapEntityToTrainingSignupDto(TrainingRegistration entity)
    {
        return new TrainingSignupDto
        {
            TrainingId = entity.Registrationid,
            ClientId = entity.Clientid,

            // DateTime = entity.Registrationdate,
        };
    }

    private TrainingSignupResponseDto? MapEntityToTrainingSignupResponseDto(TrainingRegistration entity)
    {
        return new TrainingSignupResponseDto
        {
            IsConfirmed = entity.Isconfirmed,
        };
    }
}
