using System;
using System.Collections.Generic;
using BarberShop.Domain.Models;
using BarberShop.Domain.Repositories.Contracts;

namespace BarberShop.Domain.Repositories{
    public interface IClientRepository : IRepository<Client>
    {
        IEnumerable<Client> GetAll();
        IEnumerable<Client> GetByName(string name);
    }
}