namespace FitmoRE.Application.Models.Entities.Repositories;

public interface ISubscriptionRepository
{
    void Add(Subscription subscription);

    void SaveChanges();

    Subscription GetById(int subscriptionId);

    IEnumerable<Subscription> GetAll();

    void Update(Subscription subscription);

    void Delete(int subscriptionId);
}