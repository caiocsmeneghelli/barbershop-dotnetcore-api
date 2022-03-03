using System;
using BarberShop.Domain.Models;
using BarberShop.Domain.Repositories;

namespace BarberShop.Tests.Repositories
{
    public class FakeBarberRepository : IBarberRepository
    {
        public void Create(Barber entity)
        { }

        public Barber FindById(Guid id)
        {
            return new Barber();
        }

        public void Update(Barber entity)
        { }
    }
}