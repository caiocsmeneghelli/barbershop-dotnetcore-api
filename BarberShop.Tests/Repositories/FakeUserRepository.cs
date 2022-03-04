using System;
using BarberShop.Domain.Models;
using BarberShop.Domain.Repositories;
using BarberShop.Domain.Repositories.Contracts;

namespace BarberShop.Tests.Repositories{
    public class FakeUserRepository : IUserRepository
    {
        public void Create(User entity)
        {
        }

        public User FindById(Guid id)
        {
            return new User();
        }

        public void Update(User entity)
        {
        }
    }
}