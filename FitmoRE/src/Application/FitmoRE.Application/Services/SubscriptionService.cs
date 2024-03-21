using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Models;
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
        string id = new Random().Next().ToString();
        var subscription = new SubscriptionModel(
            id,
            subscriptionDto.Price,
            DateTime.Parse(subscriptionDto.StartDate).ToString(),
            subscriptionDto.TariffModel,
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
        SubscriptionModel? subscription = _subscriptionRepository.GetById(subscriptionId);
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
            TariffModel = subscription.TariffModel,
            UserId = subscription.ClientId,
            IsActive = true,
        };
    }
}