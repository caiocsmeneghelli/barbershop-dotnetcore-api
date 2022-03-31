using System;
using System.Collections.Generic;
using BarberShop.Domain.Models;
using BarberShop.Domain.Repositories;

namespace BarberShop.Tests.Repositories
{
    public class FakeAppointmentRepository : IAppointmentRepository
    {
        public void Create(Appointment entity)
        { }

        public void Delete(Guid id)
        { }

        public Appointment FindById(Guid id)
        {
            return new Appointment();
        }

        public IEnumerable<Appointment> GetAll()
        {
            return new List<Appointment>();
        }

        public IEnumerable<Appointment> GetAllByBarber(Guid id)
        {
            return new List<Appointment>();
        }

        public IEnumerable<Appointment> GetAllToday()
        {
            return new List<Appointment>();
        }

        public IEnumerable<Appointment> GetByDate(DateTime date)
        {
            return new List<Appointment>();
        }

        public void Update(Appointment entity)
        { }
    }
}