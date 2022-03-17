using System;
using System.Collections.Generic;
using BarberShop.Domain.Models;
using BarberShop.Domain.Repositories.Contracts;

namespace BarberShop.Domain.Repositories
{
    public interface IAppointmentRepository:IRepository<Appointment>
    {
        IEnumerable<Appointment> GetAll();
        IEnumerable<Appointment> GetAllByBarber(Guid id);
        IEnumerable<Appointment> GetAllToday();
        IEnumerable<Appointment> GetByDate(DateTime date);
    }
}