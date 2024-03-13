using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Entities;
using FitmoRE.Application.Repositories;
using FitmoRE.Application.Services.Interfaces;

namespace FitmoRE.Application.Services;
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

        string id = _paymentRepository.Add(payment);
        return new SubscriptionPurchaseResponseDto
        {
            PaymentId = id,
            IsPaid = true,
        };
    }
}