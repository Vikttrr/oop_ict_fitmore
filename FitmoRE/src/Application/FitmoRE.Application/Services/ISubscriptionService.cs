namespace FitmoRE.Application.Services;

using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Entities;
using FitmoRE.Application.Repositories;

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
        var id = _subscriptionRepository.Add(subscription);

        return new AddSubscriptionResponseDto
        {
            SubscriptionId = id,
        };
    }

    public SubscriptionInfoResponseDto GetSubscriptionById(string subscriptionId)
    {
        var subscription = _subscriptionRepository.GetById(subscriptionId);
        if (subscription == null)
        {
            throw new InvalidOperationException("Subscription not found.");
        }

        return new SubscriptionInfoResponseDto()
        {
            SubscriptionId = subscription.SubscriptionId,
            Price = subscription.Price,
            StartDate = subscription.StartDate.ToString(),
            Duration = subscription.Duration,
            IsActive = true,
        };
    }
}