using FitmoRE.Application.Commands;
using FitmoRE.Application.DTO;
using FitmoRE.Application.Events.Commands;
using FitmoRE.Application.Models.Models;
using FitmoRE.Application.Repositories;
using MediatR;

namespace FitmoRE.Application.Handlers
{
    public class PurchaseSubscriptionHandler : IRequestHandler<PurchaseSubscriptionCommand, SubscriptionPurchaseResponseDto>
    {
        private readonly IPaymentRepository _paymentRepository;

        public PurchaseSubscriptionHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public Task<SubscriptionPurchaseResponseDto> Handle(PurchaseSubscriptionCommand request, CancellationToken cancellationToken)
        {
            string id = new Random().Next().ToString();
            var payment = new PaymentModel(
                id,
                request.PurchaseDto.ClientId,
                request.PurchaseDto.DateTime,
                request.PurchaseDto.Amount,
                true);

            string newId = _paymentRepository.Add(payment);

            var responseDto = new SubscriptionPurchaseResponseDto
            {
                PaymentId = newId,
                IsPaid = true,
            };

            return Task.FromResult(responseDto);
        }
    }
}