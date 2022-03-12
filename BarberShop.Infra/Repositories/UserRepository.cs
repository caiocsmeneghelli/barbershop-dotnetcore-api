using System;
using System.Collections.Generic;
using System.Linq;
using BarberShop.Domain.Models;
using BarberShop.Domain.Repositories;
using BarberShop.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public void Create(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var user = _context.Users.SingleOrDefault(reg => reg.Id == id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public User FindById(Guid id)
        {
            return _context.Users.AsNoTracking().SingleOrDefault(reg => reg.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.AsNoTracking();
        }

        public void Update(User entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}