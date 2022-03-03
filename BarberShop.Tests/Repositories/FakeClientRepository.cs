using System;
using System.Collections.Generic;
using BarberShop.Domain.Models;
using BarberShop.Domain.Repositories;

namespace BarberShop.Tests.HandlerTests.Clients
{
    public class FakeClientRepository : IClientRepository
    {
        public void Create(Client entity)
        {  }

        public Client FindById(Guid id)
        {
            return new Client();
        }

        public IEnumerable<Client> GetAll()
        {   throw new NotImplementedException(); }

        public IEnumerable<Client> GetByName()
        {
            throw new NotImplementedException();
        }

        public void Update(Client entity)
        {  }
    }
}