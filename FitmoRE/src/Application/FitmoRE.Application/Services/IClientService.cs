namespace FitmoRE.Application.Services
{
    using FitmoRE.Application.DTO;
    using FitmoRE.Application.Models.Entities;
    using FitmoRE.Application.Models.Entities.Repositories;

    public interface IClientService
    {
        Client RegisterClient(RegisterClientDto dto);

        bool AuthenticateClient(AuthenticateClientDto dto);

        Client GetClientById(int clientId);

        Payment PurchaseSubscription(PurchaseSubscriptionDto dto);

        TrainingRegistration SignupForTraining(SignupForTrainingDto dto);
    }

    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly ITrainingSessionRepository _trainingSessionRepository;

        public ClientService(IClientRepository clientRepository, IPaymentRepository paymentRepository, ITrainingSessionRepository trainingSessionRepository)
        {
            _clientRepository = clientRepository;
            _paymentRepository = paymentRepository;
            _trainingSessionRepository = trainingSessionRepository;
        }

        public Client RegisterClient(RegisterClientDto dto)
        {
            var newClient = new Client(
                dto.ClientId,
                dto.FullName,
                dto.DateOfBirth,
                dto.PhoneNumber,
                dto.Email,
                dto.Address,
                dto.IsActive);

            _clientRepository.Add(newClient);

            return newClient;
        }

        public bool AuthenticateClient(AuthenticateClientDto dto)
        {
            var client = _clientRepository.FindByPhoneNumber(dto.PhoneNumber);
            if (client != null && client.ClientId == dto.ClientId)
            {
                return true;
            }

            return false;
        }

        public Client GetClientById(int clientId)
        {
            Client client = _clientRepository.GetById(clientId);

            if (client == null)
            {
                throw new KeyNotFoundException("Client not found with ID " + clientId);
            }

            return client;
        }

        public Payment PurchaseSubscription(PurchaseSubscriptionDto dto)
        {
            DateTime paymentDate = DateTime.UtcNow;

            var payment = new Payment(
                0,
                dto.ClientId,
                paymentDate,
                dto.Amount,
                true);

            _paymentRepository.Add(payment);

            return payment;
        }

        public TrainingRegistration SignupForTraining(SignupForTrainingDto dto)
        {
            DateTime registrationDate = DateTime.UtcNow;

            var registration = new TrainingRegistration(
                0,
                dto.TrainingSessionId,
                dto.ClientId,
                registrationDate,
                false);

            _trainingSessionRepository.AddRegistration(registration);

            return registration;
        }
    }
}
