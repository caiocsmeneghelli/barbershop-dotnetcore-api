using System;
using System.Collections.Generic;
using System.Linq;
using BarberShop.Domain.Models;
using BarberShop.Domain.Repositories;
using BarberShop.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Infra.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly DataContext _context;
        public AppointmentRepository(DataContext context)
        {
            _context = context;
        }
        public void Create(Appointment entity)
        {
            _context.Appointments.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var appointment = _context.Appointments.Single(x => x.Id == id);
            _context.Appointments.Remove(appointment);
            _context.SaveChanges();
        }

        public Appointment FindById(Guid id)
        {
            return _context.Appointments.Single(x => x.Id == id);
        }

        public Appointment FindByIdAsNoTracking(Guid id)
        {
            return _context.Appointments
                .AsNoTracking()
                .Single(x => x.Id == id);
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _context.Appointments
                .Include(x => x.Barber)
                .Include(x => x.Client);
        }

        public IEnumerable<Appointment> GetAllByBarber(Guid id)
        {
            return _context.Appointments
                .AsNoTracking()
                .Where(x => x.Barber.Id == id)
                .Include(x => x.Barber).Include(x => x.Client);
        }

        public IEnumerable<Appointment> GetAllToday()
        {
            return _context.Appointments
                .AsNoTracking()
                .Where(x => x.Date.Date == DateTime.Now.Date)
                .Include(x => x.Barber).Include(x => x.Client);
        }

        public IEnumerable<Appointment> GetByDate(DateTime date)
        {
            return _context.Appointments
                .AsNoTracking().Where(x => x.Date.Date == date.Date)
                .Include(x => x.Barber).Include(x => x.Client);
        }

        public void Update(Appointment entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}