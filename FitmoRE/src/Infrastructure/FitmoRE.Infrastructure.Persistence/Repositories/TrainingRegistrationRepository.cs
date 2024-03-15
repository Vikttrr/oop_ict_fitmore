using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Entities;
using FitmoRE.Application.Repositories;
using FitmoRE.Infrastructure.Persistence.Contexts;

namespace FitmoRE.Infrastructure.Persistence.Repositories;

public class TrainingRegistrationRepository : ITrainingRegistrationRepository
{
    private readonly ApplicationDbContext _dbContext;

    public TrainingRegistrationRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public string Add(TrainingRegistration fitnessService)
    {
        FitmoRE.Infrastructure.Persistence.Entities.TrainingRegistration entity = MapTrainingRegistrationToEntity(fitnessService);
        _dbContext.TrainingRegistrations?.Add(entity);
        _dbContext.SaveChanges();
        return entity.Registrationid;
    }

    public TrainingSignupDto? GetById(string registrationId)
    {
        Entities.TrainingRegistration? entity = _dbContext.TrainingRegistrations?.FirstOrDefault(r => r.Registrationid == registrationId);
        return entity != null ? MapEntityToTrainingSignupDto(entity) : null;
    }

    public TrainingSignupResponseDto Update(FitnessService fitnessService)
    {
        throw new NotImplementedException();
    }

    public TrainingSignupResponseDto? Update(TrainingRegistration registration)
    {
        FitmoRE.Infrastructure.Persistence.Entities.TrainingRegistration? existingEntity = _dbContext.TrainingRegistrations?.FirstOrDefault(r => r.Registrationid == registration.RegistrationId);
        if (existingEntity != null)
        {
            existingEntity.Trainingid = registration.TrainingId;
            existingEntity.Clientid = registration.ClientId;

            // existingEntity.Registrationdate = registration.RegistrationDate;
            existingEntity.Isconfirmed = registration.IsConfirmed;
            _dbContext.SaveChanges();
            return MapEntityToTrainingSignupResponseDto(existingEntity);
        }

        return null;
    }

    public TrainingSignupDto? Delete(string registrationId)
    {
        FitmoRE.Infrastructure.Persistence.Entities.TrainingRegistration? entity = _dbContext.TrainingRegistrations?.FirstOrDefault(r => r.Registrationid == registrationId);
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

    private FitmoRE.Infrastructure.Persistence.Entities.TrainingRegistration MapTrainingRegistrationToEntity(TrainingRegistration model)
    {
        return new FitmoRE.Infrastructure.Persistence.Entities.TrainingRegistration
        {
            Registrationid = model.RegistrationId,
            Trainingid = model.TrainingId,
            Clientid = model.ClientId,

            // Registrationdate = model.RegistrationDate,
            Isconfirmed = model.IsConfirmed,
        };
    }

    private TrainingSignupDto? MapEntityToTrainingSignupDto(FitmoRE.Infrastructure.Persistence.Entities.TrainingRegistration entity)
    {
        return new TrainingSignupDto
        {
            TrainingId = entity.Registrationid,
            ClientId = entity.Clientid,

            // DateTime = entity.Registrationdate,
        };
    }

    private TrainingSignupResponseDto? MapEntityToTrainingSignupResponseDto(FitmoRE.Infrastructure.Persistence.Entities.TrainingRegistration entity)
    {
        return new TrainingSignupResponseDto
        {
            IsConfirmed = entity.Isconfirmed,
        };
    }
}
