using FitmoRE.Application.DTO;
using MediatR;

namespace FitmoRE.Application.Events.Commands;

public class PurchaseSubscriptionCommand : IRequest<SubscriptionPurchaseResponseDto>
{
    public SubscriptionPurchaseDto PurchaseDto { get; }

    public PurchaseSubscriptionCommand(SubscriptionPurchaseDto purchaseDto)
    {
        PurchaseDto = purchaseDto;
    }
}