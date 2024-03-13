using FitmoRE.Application.DTO;

namespace FitmoRE.Application.Services.Interfaces;
public interface ISubscriptionService
{
    AddSubscriptionResponseDto AddSubscription(AddSubscriptionDto subscriptionDto);

    SubscriptionInfoResponseDto GetSubscriptionById(string subscriptionId);
}