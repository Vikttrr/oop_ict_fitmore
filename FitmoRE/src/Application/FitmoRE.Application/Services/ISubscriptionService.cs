using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Entities;
using FitmoRE.Application.Models.Entities.Repositories;

namespace FitmoRE.Application.Services;
public interface ISubscriptionService
{
    void AddSubscription(AddSubscriptionDto subscriptionDto);

    Subscription GetSubscriptionById(string subscriptionId);
}

public class SubscriptionService : ISubscriptionService
{
    private readonly ISubscriptionRepository _subscriptionRepository;

    public SubscriptionService(ISubscriptionRepository subscriptionRepository)
    {
        _subscriptionRepository = subscriptionRepository;
    }

    public void AddSubscription(AddSubscriptionDto subscriptionDto)
    {
        var subscription = new Subscription(
            0,
            subscriptionDto.Price,
            subscriptionDto.StartDate,
            subscriptionDto.Duration,
            subscriptionDto.IsActive);
        _subscriptionRepository.Add(subscription);
    }

    public Subscription GetSubscriptionById(string subscriptionId)
    {
        return _subscriptionRepository.GetById(subscriptionId);
    }
}