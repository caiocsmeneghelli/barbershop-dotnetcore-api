using System;
using System.Collections.Generic;
using System.Linq;
using BarberShop.Domain.Models;
using BarberShop.Domain.Repositories;
using BarberShop.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Infra.Repositories
{
    public class BarberRepository : IBarberRepository
    {
        private readonly DataContext _context;
        public BarberRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Barber entity)
        {
            _context.Barbers.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var barber = _context.Barbers.Single(x => x.Id == id);
            _context.Barbers.Remove(barber);
            _context.SaveChanges();
        }

        public Barber FindById(Guid id)
        {
            return _context.Barbers.SingleOrDefault(x => x.Id == id);
        }

        public Barber FindByIdAsNoTracking(Guid id)
        {
            return _context.Barbers.AsNoTracking().SingleOrDefault(x => x.Id == id);
        }
        public IEnumerable<Barber> GetAll()
        {
            return _context.Barbers.AsNoTracking();
        }

        public void Update(Barber entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}