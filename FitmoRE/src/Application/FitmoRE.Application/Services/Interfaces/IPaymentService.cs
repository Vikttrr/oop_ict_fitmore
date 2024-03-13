using FitmoRE.Application.DTO;

namespace FitmoRE.Application.Services.Interfaces;
public interface IPaymentService
{
    SubscriptionPurchaseResponseDto PurchaseSubscription(SubscriptionPurchaseDto purchaseDto);
}