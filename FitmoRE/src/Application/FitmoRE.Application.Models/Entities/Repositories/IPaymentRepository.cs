namespace FitmoRE.Application.Models.Entities.Repositories;

public interface IPaymentRepository
{
    void Add(Payment payment);

    Payment GetById(int paymentId);

    void Update(Payment payment);

    IEnumerable<Payment> FindByClientId(int clientId);
}