using System;
using BarberShop.Domain.Entities;

namespace BarberShop.Domain.Models
{
    public class Appointment : Entity
    {
        public DateTime Date { get; protected set; }
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

        public void RoundHour()
        {
            if(Date.Minute > 0 && Date.Minute <= 30)
            {
                Date = Date
                    .AddMinutes(-Date.Minute)
                    .AddSeconds(-Date.Second);
            }
            else if(this.Date.Minute > 30)
            {
                Date = Date
                    .AddHours(1)
                    .AddMinutes(-Date.Minute)
                    .AddSeconds(-Date.Second);
            }
        }
        public void ChangeDate(DateTime newDate)
        {
            Date = newDate;
            RoundHour();
        }

        public void ChangeBarber(Barber newBarber)
        {
            Barber = newBarber;
        }
    }
}