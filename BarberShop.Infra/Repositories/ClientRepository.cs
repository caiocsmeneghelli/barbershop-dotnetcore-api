using System;
using System.Collections.Generic;
using System.Linq;
using BarberShop.Domain.Models;
using BarberShop.Domain.Repositories;
using BarberShop.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Infra.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataContext _context;
        public ClientRepository(DataContext context)
        {
            _context = context;
        }
        public void Create(Client entity)
        {
            _context.Clients.Add(entity);
            _context.SaveChanges();
        }

        public Client FindById(Guid id)
        {
            return _context.Clients.SingleOrDefault(reg => reg.Id == id);
        }

        public IEnumerable<Client> GetAll()
        {
            return _context.Clients.AsNoTracking();
        }

        public IEnumerable<Client> GetByName(string name)
        {
            return _context.Clients
                    .AsNoTracking()
                    .Where(reg => reg.Name.ToLower().Contains(name.ToLower())
                    || reg.LastName.ToLower().Contains(name.ToLower()));
        }

        public void Update(Client entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var client = _context.Clients.Single(reg => reg.Id == id);
            _context.Clients.Remove(client);
            _context.SaveChanges();
        }

        public Client FindByIdAsNoTracking(Guid id)
        {
            return _context.Clients.AsNoTracking().SingleOrDefault(reg => reg.Id == id);
        }
    }
}