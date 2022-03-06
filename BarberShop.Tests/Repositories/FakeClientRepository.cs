using System;
using System.Collections.Generic;
using BarberShop.Domain.Models;
using BarberShop.Domain.Repositories;

namespace BarberShop.Tests.Repositories
{
    public class FakeClientRepository : IClientRepository
    {
        public void Create(Client entity)
        {  }

        public void Delete(Guid id)
        { }

        public Client FindById(Guid id)
        {
            return new Client();
        }

        public IEnumerable<Client> GetAll()
        {   throw new NotImplementedException(); }

        public IEnumerable<Client> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(Client entity)
        {  }
    }
}