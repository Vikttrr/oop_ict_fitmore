using FitmoRE.Application.DTO;
using FitmoRE.Application.Events.Queries;
using FitmoRE.Application.Models.Models;
using FitmoRE.Application.Repositories;
using MediatR;

namespace FitmoRE.Application.Events.Handlers;

public class GetSubscriptionByIdQueryHandler : IRequestHandler<GetSubscriptionByIdQuery, SubscriptionInfoResponseDto>
{
    private readonly ISubscriptionRepository _subscriptionRepository;

    public GetSubscriptionByIdQueryHandler(ISubscriptionRepository subscriptionRepository)
    {
        _subscriptionRepository = subscriptionRepository;
    }

    public Task<SubscriptionInfoResponseDto> Handle(GetSubscriptionByIdQuery request, CancellationToken cancellationToken)
    {
        SubscriptionModel? subscription = _subscriptionRepository.GetById(request.SubscriptionId);
        if (subscription == null)
        {
            return Task.FromResult(new SubscriptionInfoResponseDto()
            {
                StartDate = string.Empty,
            });
        }

        var responseDto = new SubscriptionInfoResponseDto()
        {
            SubscriptionId = subscription.SubscriptionId,
            Price = subscription.Price,
            StartDate = subscription.StartDate,
            TariffModel = subscription.TariffModel,
            UserId = subscription.ClientId,
            IsActive = true,
        };

        return Task.FromResult(responseDto);
    }
}