using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Entities;
using FitmoRE.Application.Repositories;
using FitmoRE.Infrastructure.Persistence.Contexts;

namespace FitmoRE.Infrastructure.Persistence.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly ApplicationDbContext _dbContext;

    public PaymentRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public string Add(Payment payment)
    {
        FitmoRE.Infrastructure.Persistence.Entities.Payment entity = MapPaymentToEntity(payment);
        _dbContext.Payments?.Add(entity);
        _dbContext.SaveChanges();
        return entity.Paymentid;
    }

    public Payment GetById(string paymentId)
    {
        FitmoRE.Infrastructure.Persistence.Entities.Payment? entity = _dbContext.Payments?.FirstOrDefault(c => c.Paymentid == paymentId);
        return (entity != null ? MapEntityToPayment(entity) : null) ?? throw new InvalidOperationException();
    }

    public SubscriptionPurchaseResponseDto? Update(Payment payment)
    {
        FitmoRE.Infrastructure.Persistence.Entities.Payment? existingEntity = _dbContext.Payments?.FirstOrDefault(p => p.Paymentid == payment.PaymentId);
        if (existingEntity != null)
        {
            existingEntity.Clientid = payment.ClientId;
            existingEntity.Date = payment.Date;
            existingEntity.Amount = payment.Amount;
            existingEntity.Ispaid = payment.IsPaid;

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

    private Payment MapEntityToPayment(FitmoRE.Infrastructure.Persistence.Entities.Payment entity)
    {
        return new Payment
        {
            PaymentId = entity.Paymentid,
            ClientId = entity.Clientid,
            Date = entity.Date,
            Amount = entity.Amount ?? 0,
            IsPaid = entity.Ispaid,
        };
    }

    private FitmoRE.Infrastructure.Persistence.Entities.Payment MapPaymentToEntity(Payment model)
    {
        return new FitmoRE.Infrastructure.Persistence.Entities.Payment
        {
            Paymentid = model.PaymentId,
            Clientid = model.ClientId,
            Date = model.Date,
            Amount = model.Amount,
            Ispaid = model.IsPaid,
        };
    }

    private SubscriptionPurchaseResponseDto? MapEntityToSubscriptionPurchaseResponseDto(FitmoRE.Infrastructure.Persistence.Entities.Payment entity)
    {
        return new SubscriptionPurchaseResponseDto
        {
            PaymentId = entity.Paymentid,
            IsPaid = entity.Ispaid,
        };
    }
}
