using FitmoRE.Application.DTO;

namespace FitmoRE.Application.Models.Entities.Repositories
{
    public interface IPaymentRepository
    {
        SubscriptionPurchaseResponseDto Add(Payment paymentDto);

        SubscriptionPurchaseResponseDto GetById(string paymentId);

        SubscriptionPurchaseResponseDto Update(SubscriptionPurchaseDto paymentDto);

        IEnumerable<SubscriptionPurchaseResponseDto> FindByClientId(string clientId);
    }
}