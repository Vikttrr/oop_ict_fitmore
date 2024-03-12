using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Entities;
using FitmoRE.Application.Repositories;

namespace FitmoRE.Application.Services;
public interface IPaymentService
{
    SubscriptionPurchaseResponseDto PurchaseSubscription(SubscriptionPurchaseDto purchaseDto);
}

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _paymentRepository;

    public PaymentService(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public SubscriptionPurchaseResponseDto PurchaseSubscription(SubscriptionPurchaseDto purchaseDto)
    {
        var payment = new Payment(
            string.Empty,
            purchaseDto.ClientId,
            DateTime.Parse(purchaseDto.DateTime),
            purchaseDto.Amount,
            true);

        var id = _paymentRepository.Add(payment);
        return new SubscriptionPurchaseResponseDto
        {
            PaymentId = id,
            IsPaid = true,
        };
    }
}