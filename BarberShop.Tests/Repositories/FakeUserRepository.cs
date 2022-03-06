using System;
using System.Collections.Generic;
using BarberShop.Domain.Models;
using BarberShop.Domain.Repositories;
using BarberShop.Domain.Repositories.Contracts;

namespace BarberShop.Tests.Repositories{
    public class FakeUserRepository : IUserRepository
    {
        public void Create(User entity)
        {
        }

        public void Delete(Guid id)
        { }

        public User FindById(Guid id)
        {
            return new User();
        }

        public IEnumerable<User> GetAll()
        {
            return new List<User>();
        }

        public void Update(User entity)
        {
        }
    }
}