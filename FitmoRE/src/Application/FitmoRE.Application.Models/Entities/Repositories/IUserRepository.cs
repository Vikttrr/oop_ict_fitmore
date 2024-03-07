namespace FitmoRE.Application.Models.Entities.Repositories
{
    public interface IUserRepository
    {
        void Add(Client client);

        Client GetById(int clientId);

        Client FindByPhoneAndClientId(string phone, int clientId);

        void Update(Client client);

        void Delete(int clientId);

        IEnumerable<Client> GetAll();
    }
}