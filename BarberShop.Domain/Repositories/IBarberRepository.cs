using System.Collections.Generic;
using BarberShop.Domain.Commands.Barbers;
using BarberShop.Domain.Models;
using BarberShop.Domain.Repositories.Contracts;

namespace BarberShop.Domain.Repositories
{
    public interface IBarberRepository : IRepository<Barber>
    {
        IEnumerable<Barber> GetAll();
    }
}