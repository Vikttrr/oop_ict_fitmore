namespace FitmoRE.Application.Models.Entities.Repositories;

public partial interface IClientRepository
{
    void Add(Client client);

    Client GetById(int clientId);

    Client FindByPhoneNumber(string phoneNumber);

    IEnumerable<Client> GetAll();

    void Update(Client client);

    void Remove(Client client);
}