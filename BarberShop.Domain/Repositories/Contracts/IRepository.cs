using System;
using BarberShop.Domain.Entities;

namespace BarberShop.Domain.Repositories.Contracts
{
    public interface IRepository<T> where T : Entity
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(Guid id);
        T FindById(Guid id);
    }
}