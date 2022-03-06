using System.Collections.Generic;
using BarberShop.Domain.Models;
using BarberShop.Domain.Repositories.Contracts;

namespace BarberShop.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetAll();
    }
}