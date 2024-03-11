using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Entities;
using FitmoRE.Application.Models.Entities.Repositories;

namespace FitmoRE.Application.Services;
public interface ISubscriptionService
{
    AddSubscriptionResponseDto AddSubscription(AddSubscriptionDto subscriptionDto);

    SubscriptionInfoResponseDto GetSubscriptionById(string subscriptionId);
}

public class SubscriptionService : ISubscriptionService
{
    private readonly ISubscriptionRepository _subscriptionRepository;

    public SubscriptionService(ISubscriptionRepository subscriptionRepository)
    {
        _subscriptionRepository = subscriptionRepository;
    }

    public AddSubscriptionResponseDto AddSubscription(AddSubscriptionDto subscriptionDto)
    {
        var subscription = new Subscription(
            string.Empty,
            subscriptionDto.Price,
            DateTime.Parse(subscriptionDto.StartDate).ToString(),
            subscriptionDto.Duration,
            subscriptionDto.IsActive);
        _subscriptionRepository.Add(subscription);

        return new AddSubscriptionResponseDto
        {
            SubscriptionId = subscription.SubscriptionId,
        };
    }

    public SubscriptionDto GetSubscriptionById(string subscriptionId)
    {
        var subscription = _subscriptionRepository.GetById(subscriptionId);
        if (subscription == null)
        {
            throw new InvalidOperationException("Subscription not found.");
        }

        return new SubscriptionDto
        {
            SubscriptionId = subscription.SubscriptionId,
            Price = subscription.Price,
            StartDate = subscription.StartDate.ToString(),
            Duration = subscription.Duration,
            IsActive = true,
        };
    }
}