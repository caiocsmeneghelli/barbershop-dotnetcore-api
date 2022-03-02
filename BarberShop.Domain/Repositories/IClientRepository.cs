using BarberShop.Domain.Models;

public interface IClientRepository{
    void Create(Client client);
    void Update(Client client);
}