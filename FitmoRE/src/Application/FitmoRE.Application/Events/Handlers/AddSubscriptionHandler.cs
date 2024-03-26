using FitmoRE.Application.DTO;
using FitmoRE.Application.Events.Commands;
using FitmoRE.Application.Models.Models;
using FitmoRE.Application.Repositories;
using MediatR;

namespace FitmoRE.Application.Events.Handlers;

public class AddSubscriptionHandler : IRequestHandler<AddSubscriptionCommand, AddSubscriptionResponseDto>
{
    private readonly ISubscriptionRepository _subscriptionRepository;

    public AddSubscriptionHandler(ISubscriptionRepository subscriptionRepository)
    {
        _subscriptionRepository = subscriptionRepository;
    }

    public Task<AddSubscriptionResponseDto> Handle(AddSubscriptionCommand request, CancellationToken cancellationToken)
    {
        string id = new Random().Next().ToString();
        var subscription = new SubscriptionModel(
            id,
            request.SubscriptionDto.Price,
            request.SubscriptionDto.StartDate,
            request.SubscriptionDto.TariffModel,
            request.SubscriptionDto.UserId,
            request.SubscriptionDto.IsActive);

        string newId = _subscriptionRepository.Add(subscription);

        var responseDto = new AddSubscriptionResponseDto { SubscriptionId = newId };

        return Task.FromResult(responseDto);
    }
}
