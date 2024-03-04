namespace FitmoRE.Application.Services
{
    using FitmoRE.Application.DTO;
    using FitmoRE.Application.Models.Entities;
    using FitmoRE.Application.Models.Entities.Repositories;

    public interface ISubscriptionService
    {
        Subscription AddSubscription(SubscriptionDto dto);
    }

    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public SubscriptionService(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public Subscription AddSubscription(SubscriptionDto dto)
        {
            var subscription = new Subscription(
                0,
                dto.Price,
                dto.StartDate,
                dto.Duration,
                dto.IsActive);

            _subscriptionRepository.Add(subscription);
            _subscriptionRepository.SaveChanges();

            return subscription;
        }
    }
}