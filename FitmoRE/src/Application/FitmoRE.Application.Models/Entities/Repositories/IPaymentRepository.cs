namespace FitmoRE.Application.Models.Entities.Repositories;

public interface IPaymentRepository
{
    void Add(Payment payment);

    Payment GetById(int paymentId);

    IEnumerable<Payment> GetPaymentsForClient(int clientId);

    void Update(Payment payment);

    void Remove(Payment payment);
}