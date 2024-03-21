using FitmoRE.Application.Models.Models;

namespace FitmoRE.Application.Repositories;
public interface ISubscriptionRepository
{
    string Add(SubscriptionModel subscriptionModel);

    SubscriptionModel? GetById(string subscriptionId);

    SubscriptionModel? Update(SubscriptionModel subscriptionModel);

    SubscriptionModel? Delete(string subscriptionId);

    IEnumerable<SubscriptionModel?> GetAll();

    IEnumerable<SubscriptionModel?> FindByClientId(string clientId);
}