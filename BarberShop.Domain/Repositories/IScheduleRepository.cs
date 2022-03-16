using System;
using System.Collections.Generic;
using BarberShop.Domain.Models;
using BarberShop.Domain.Repositories.Contracts;

namespace BarberShop.Domain.Repositories
{
    public interface IScheduleRepository:IRepository<Schedule>
    {
        IEnumerable<Schedule> GetAll();
        IEnumerable<Schedule> GetAllByBarber(Guid id);
        IEnumerable<Schedule> GetAllToday();
    }
}