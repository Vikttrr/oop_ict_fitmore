namespace FitmoRE.Application.Repositories;

using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Entities;

public interface ISubscriptionRepository
{
    string Add(Subscription subscription);

    Subscription GetById(string subscriptionId);

    Subscription Update(AddSubscriptionDto subscriptionDto);

    Subscription Delete(string subscriptionId);

    IEnumerable<Subscription> GetAll();

    IEnumerable<Subscription> FindByClientId(string clientId);
}