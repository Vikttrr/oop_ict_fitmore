using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Entities;
using FitmoRE.Application.Repositories;
using FitmoRE.Application.Services.Interfaces;

namespace FitmoRE.Application.Services;
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
            subscriptionDto.Tariff,
            subscriptionDto.UserId,
            subscriptionDto.IsActive);
        string id = _subscriptionRepository.Add(subscription);

        return new AddSubscriptionResponseDto
        {
            SubscriptionId = id,
        };
    }

    public SubscriptionInfoResponseDto GetSubscriptionById(string subscriptionId)
    {
        Subscription? subscription = _subscriptionRepository.GetById(subscriptionId);
        if (subscription == null)
        {
            // throw new InvalidOperationException("Subscription not found.");
            return new SubscriptionInfoResponseDto()
            {
                StartDate = string.Empty,
            };
        }

        return new SubscriptionInfoResponseDto()
        {
            SubscriptionId = subscription.SubscriptionId,
            Price = subscription.Price,
            StartDate = subscription.StartDate,
            Tariff = subscription.Tariff,
            UserId = subscription.ClientId,
            IsActive = true,
        };
    }
}