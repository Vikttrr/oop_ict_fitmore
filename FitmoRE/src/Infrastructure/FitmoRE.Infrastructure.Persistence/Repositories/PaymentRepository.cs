using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Models;
using FitmoRE.Application.Repositories;
using FitmoRE.Infrastructure.Persistence.Contexts;
using FitmoRE.Infrastructure.Persistence.Entities;

namespace FitmoRE.Infrastructure.Persistence.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly ApplicationDbContext _dbContext;

    public PaymentRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public string Add(PaymentModel paymentModel)
    {
        Payment entity = MapPaymentToEntity(paymentModel);
        _dbContext.Payments?.Add(entity);
        _dbContext.SaveChanges();
        return entity.Paymentid;
    }

    public PaymentModel GetById(string paymentId)
    {
        Payment? entity = _dbContext.Payments?.FirstOrDefault(c => c.Paymentid == paymentId);
        return (entity != null ? MapEntityToPayment(entity) : null) ?? throw new InvalidOperationException();
    }

    public SubscriptionPurchaseResponseDto? Update(PaymentModel paymentModel)
    {
        Payment? existingEntity = _dbContext.Payments?.FirstOrDefault(p => p.Paymentid == paymentModel.PaymentId);
        if (existingEntity != null)
        {
            existingEntity.Clientid = paymentModel.ClientId;
            existingEntity.Date = paymentModel.Date;
            existingEntity.Amount = paymentModel.Amount;
            existingEntity.Ispaid = paymentModel.IsPaid;

            _dbContext.SaveChanges();

            return MapEntityToSubscriptionPurchaseResponseDto(existingEntity);
        }

        return null;
    }

    public IEnumerable<SubscriptionPurchaseResponseDto?> FindByClientId(string clientId)
    {
        var entities = _dbContext.Payments?.Where(p => p.Clientid == clientId).ToList();
        return (entities ?? throw new InvalidOperationException()).Select(MapEntityToSubscriptionPurchaseResponseDto);
    }

    private PaymentModel MapEntityToPayment(Payment entity)
    {
        return new PaymentModel
        {
            PaymentId = entity.Paymentid,
            ClientId = entity.Clientid,
            Date = entity.Date,
            Amount = entity.Amount ?? 0,
            IsPaid = entity.Ispaid,
        };
    }

    private Payment MapPaymentToEntity(PaymentModel model)
    {
        return new Payment
        {
            Paymentid = model.PaymentId,
            Clientid = model.ClientId,
            Date = model.Date,
            Amount = model.Amount,
            Ispaid = model.IsPaid,
        };
    }

    private SubscriptionPurchaseResponseDto? MapEntityToSubscriptionPurchaseResponseDto(Payment entity)
    {
        return new SubscriptionPurchaseResponseDto
        {
            PaymentId = entity.Paymentid,
            IsPaid = entity.Ispaid,
        };
    }
}
