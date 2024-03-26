using FitmoRE.Application.DTO;
using MediatR;

namespace FitmoRE.Application.Events.Queries;

public class GetSubscriptionByIdQuery : IRequest<SubscriptionInfoResponseDto>
{
    public string SubscriptionId { get; }

    public GetSubscriptionByIdQuery(string subscriptionId)
    {
        SubscriptionId = subscriptionId;
    }
}