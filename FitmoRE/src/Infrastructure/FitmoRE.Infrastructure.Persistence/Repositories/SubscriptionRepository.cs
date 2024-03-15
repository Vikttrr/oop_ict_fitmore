using FitmoRE.Application.Models.Entities;
using FitmoRE.Application.Repositories;
using FitmoRE.Infrastructure.Persistence.Contexts;

namespace FitmoRE.Infrastructure.Persistence.Repositories;

public class SubscriptionRepository : ISubscriptionRepository
{
    private readonly ApplicationDbContext _dbContext;

    public SubscriptionRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public string Add(Subscription subscription)
    {
        Entities.Subscription entity = MapSubscriptionToEntity(subscription);
        _dbContext.Subscriptions?.Add(entity);
        _dbContext.SaveChanges();
        return entity.Subscriptionid;
    }

    public Subscription? GetById(string subscriptionId)
    {
        Entities.Subscription? entity = _dbContext.Subscriptions?.FirstOrDefault(s => s.Subscriptionid == subscriptionId);
        return entity != null ? MapEntityToSubscription(entity) : null;
    }

    public Subscription? Update(Subscription subscription)
    {
        Entities.Subscription? existingEntity = _dbContext.Subscriptions?.FirstOrDefault(s => s.Subscriptionid == subscription.SubscriptionId);
        if (existingEntity != null)
        {
            existingEntity.Price = subscription.Price;
            existingEntity.Startdate = subscription.StartDate;
            existingEntity.Clientid = subscription.ClientId;
            existingEntity.Isactive = subscription.IsActive;

            _dbContext.SaveChanges();

            return MapEntityToSubscription(existingEntity);
        }

        return null;
    }

    public Subscription? Delete(string subscriptionId)
    {
        Entities.Subscription? entity = _dbContext.Subscriptions?.FirstOrDefault(s => s.Subscriptionid == subscriptionId);
        if (entity != null)
        {
            _dbContext.Subscriptions?.Remove(entity);
            _dbContext.SaveChanges();
            return MapEntityToSubscription(entity);
        }

        return null;
    }

    public IEnumerable<Subscription?> GetAll()
    {
        var entities = _dbContext.Subscriptions?.ToList();
        return (entities ?? throw new InvalidOperationException()).Select(MapEntityToSubscription);
    }

    public IEnumerable<Subscription?> FindByClientId(string clientId)
    {
        var entities = _dbContext.Subscriptions?.Where(s => s.Clientid == clientId).ToList();
        return (entities ?? throw new InvalidOperationException()).Select(MapEntityToSubscription);
    }

    private Subscription? MapEntityToSubscription(FitmoRE.Infrastructure.Persistence.Entities.Subscription entity)
    {
        return new Subscription(
            entity.Subscriptionid,
            entity.Price ?? 0,
            entity.Startdate ?? string.Empty,
            new Tariff(0, 0),
            entity.Clientid ?? string.Empty,
            true);
    }

    private FitmoRE.Infrastructure.Persistence.Entities.Subscription MapSubscriptionToEntity(Subscription model)
    {
        return new FitmoRE.Infrastructure.Persistence.Entities.Subscription
        {
            Subscriptionid = model.SubscriptionId,
            Price = model.Price,
            Startdate = model.StartDate,
            Clientid = model.ClientId,
            Isactive = model.IsActive,
        };
    }
}