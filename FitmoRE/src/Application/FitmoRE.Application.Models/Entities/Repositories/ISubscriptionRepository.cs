namespace FitmoRE.Application.Models.Entities.Repositories
{
    public interface ISubscriptionRepository
    {
        void Add(Subscription subscription);

        Subscription GetById(string subscriptionId);

        void Update(Subscription subscription);

        void Delete(string subscriptionId);

        IEnumerable<Subscription> GetAll();

        IEnumerable<Subscription> FindByClientId(int clientId);
    }
}