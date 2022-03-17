using System;
using BarberShop.Domain.Entities;

namespace BarberShop.Domain.Models
{
    public class Appointment : Entity
    {
        public DateTime Date { get; private set; }
        public Barber Barber { get; private set; }
        public Client Client { get; private set; }

        public Appointment()
        { }
        public Appointment(DateTime date, Barber barber, Client client)
        {
            Date = date;
            Barber = barber;
            Client = client;
        }

        public void ChangeDate(DateTime newDate)
        {
            Date = newDate;
        }

        public void ChangeBarber(Barber newBarber)
        {
            Barber = newBarber;
        }
    }
}