using FitmoRE.Application.DTO;

namespace FitmoRE.Application.Models.Entities.Repositories
{
    public interface ISubscriptionRepository
    {
        AddSubscriptionResponseDto Add(Subscription subscriptionDto);

        SubscriptionDto GetById(string subscriptionId);

        SubscriptionDto Update(AddSubscriptionDto subscriptionDto);

        SubscriptionDto Delete(string subscriptionId);

        IEnumerable<SubscriptionDto> GetAll();

        IEnumerable<SubscriptionDto> FindByClientId(string clientId);
    }
}