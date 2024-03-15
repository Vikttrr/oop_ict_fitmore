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
        var id = new Random().Next().ToString();
        var subscription = new Subscription(
            id,
            subscriptionDto.Price,
            DateTime.Parse(subscriptionDto.StartDate).ToString(),
            subscriptionDto.Tariff,
            subscriptionDto.UserId,
            subscriptionDto.IsActive);
        string newId = _subscriptionRepository.Add(subscription);

        return new AddSubscriptionResponseDto
        {
            SubscriptionId = newId,
        };
    }

    public SubscriptionInfoResponseDto GetSubscriptionById(string subscriptionId)
    {
        Subscription? subscription = _subscriptionRepository.GetById(subscriptionId);
        if (subscription == null)
        {
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