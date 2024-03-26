using FitmoRE.Application.DTO;
using MediatR;

namespace FitmoRE.Application.Events.Commands;

public class AddSubscriptionCommand : IRequest<AddSubscriptionResponseDto>
{
    public AddSubscriptionDto SubscriptionDto { get; set; }

    public AddSubscriptionCommand(AddSubscriptionDto subscriptionDto)
    {
        SubscriptionDto = subscriptionDto;
    }
}
