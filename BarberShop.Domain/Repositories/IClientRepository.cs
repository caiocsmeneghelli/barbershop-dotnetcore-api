using System;
using BarberShop.Domain.Models;
using BarberShop.Domain.Repositories.Contracts;

namespace BarberShop.Domain.Repositories{
    public interface IClientRepository : IRepository<Client>
    {
        
    }
}