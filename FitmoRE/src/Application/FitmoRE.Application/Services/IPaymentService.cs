using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Entities;
using FitmoRE.Application.Models.Entities.Repositories;

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
            0,
            purchaseDto.ClientId,
            DateTime.Parse(purchaseDto.DateTime),
            purchaseDto.Amount,
            true);

        _paymentRepository.Add(payment);

        return new SubscriptionPurchaseResponseDto
        {
            PaymentId = payment.PaymentId.ToString(),
            IsPaid = true,
        };
    }
}