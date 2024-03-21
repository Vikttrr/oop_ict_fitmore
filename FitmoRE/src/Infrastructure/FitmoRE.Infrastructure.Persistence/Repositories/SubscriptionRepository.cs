using FitmoRE.Application.Models.Models;
using FitmoRE.Application.Repositories;
using FitmoRE.Infrastructure.Persistence.Contexts;
using FitmoRE.Infrastructure.Persistence.Entities;

namespace FitmoRE.Infrastructure.Persistence.Repositories;

public class SubscriptionRepository : ISubscriptionRepository
{
    private readonly ApplicationDbContext _dbContext;

    public SubscriptionRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public string Add(SubscriptionModel subscriptionModel)
    {
        Subscription entity = MapSubscriptionToEntity(subscriptionModel);
        _dbContext.Subscriptions?.Add(entity);
        _dbContext.SaveChanges();
        return entity.Subscriptionid;
    }

    public SubscriptionModel? GetById(string subscriptionId)
    {
        Subscription? entity = _dbContext.Subscriptions?.FirstOrDefault(s => s.Subscriptionid == subscriptionId);
        return entity != null ? MapEntityToSubscription(entity) : null;
    }

    public SubscriptionModel? Update(SubscriptionModel subscriptionModel)
    {
        Subscription? existingEntity = _dbContext.Subscriptions?.FirstOrDefault(s => s.Subscriptionid == subscriptionModel.SubscriptionId);
        if (existingEntity != null)
        {
            existingEntity.Price = subscriptionModel.Price;
            existingEntity.Startdate = subscriptionModel.StartDate;
            existingEntity.Clientid = subscriptionModel.ClientId;
            existingEntity.Isactive = subscriptionModel.IsActive;

            _dbContext.SaveChanges();

            return MapEntityToSubscription(existingEntity);
        }

        return null;
    }

    public SubscriptionModel? Delete(string subscriptionId)
    {
        Subscription? entity = _dbContext.Subscriptions?.FirstOrDefault(s => s.Subscriptionid == subscriptionId);
        if (entity != null)
        {
            _dbContext.Subscriptions?.Remove(entity);
            _dbContext.SaveChanges();
            return MapEntityToSubscription(entity);
        }

        return null;
    }

    public IEnumerable<SubscriptionModel?> GetAll()
    {
        var entities = _dbContext.Subscriptions?.ToList();
        return (entities ?? throw new InvalidOperationException()).Select(MapEntityToSubscription);
    }

    public IEnumerable<SubscriptionModel?> FindByClientId(string clientId)
    {
        var entities = _dbContext.Subscriptions?.Where(s => s.Clientid == clientId).ToList();
        return (entities ?? throw new InvalidOperationException()).Select(MapEntityToSubscription);
    }

    private SubscriptionModel? MapEntityToSubscription(Subscription entity)
    {
        return new SubscriptionModel(
            entity.Subscriptionid,
            entity.Price ?? 0,
            entity.Startdate ?? string.Empty,
            new TariffModel(0, 0),
            entity.Clientid ?? string.Empty,
            true);
    }

    private Subscription MapSubscriptionToEntity(SubscriptionModel model)
    {
        return new Subscription
        {
            Subscriptionid = model.SubscriptionId,
            Price = model.Price,
            Startdate = model.StartDate,
            Clientid = model.ClientId,
            Isactive = model.IsActive,
        };
    }
}