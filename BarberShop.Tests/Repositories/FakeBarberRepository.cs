using System;
using System.Collections.Generic;
using BarberShop.Domain.Models;
using BarberShop.Domain.Repositories;

namespace BarberShop.Tests.Repositories
{
    public class FakeBarberRepository : IBarberRepository
    {
        public void Create(Barber entity)
        { }

        public void Delete(Guid id)
        { }

        public Barber FindById(Guid id)
        {
            return new Barber();
        }

        public IEnumerable<Barber> GetAll()
        {
            return new List<Barber>();
        }

        public void Update(Barber entity)
        { }
    }
}