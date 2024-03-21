using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Models;

namespace FitmoRE.Application.Repositories;
public interface IPaymentRepository
{
    string Add(PaymentModel paymentModel);

    PaymentModel GetById(string paymentId);

    SubscriptionPurchaseResponseDto? Update(PaymentModel paymentModel);

    IEnumerable<SubscriptionPurchaseResponseDto?> FindByClientId(string clientId);
}