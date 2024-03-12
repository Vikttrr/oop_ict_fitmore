using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Entities;

namespace FitmoRE.Application.Repositories;
public interface IPaymentRepository
{
    string Add(Payment payment);

    Subscription GetById(string paymentId);

    SubscriptionPurchaseResponseDto Update(Payment payment);

    IEnumerable<SubscriptionPurchaseResponseDto> FindByClientId(string clientId);
}