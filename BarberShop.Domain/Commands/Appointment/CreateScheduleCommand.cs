using System;
using BarberShop.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace BarberShop.Domain.Commands.Appointment
{
    public class CreateAppointmentCommand : Notifiable, ICommand
    {
        public Guid IdBarber { get; set; }
        public Guid IdClient { get; set; }
        public DateTime DateTime { get; set; }
        public CreateAppointmentCommand()
        { }

        public CreateAppointmentCommand(Guid idBarber, Guid idClient, DateTime dateTime)
        {
            IdBarber = idBarber;
            IdClient = idClient;
            DateTime = dateTime;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(IdBarber.ToString(), "IdBarber", "Barber cannot be null or empty.")
                    .IsNotNullOrEmpty(IdClient.ToString(), "IdClient", "Client cannot be null or empty.")
                    .IsNotNullOrEmpty(DateTime.ToString(), "DateTime", "DateTime cannot be null")
            );
        }
    }
}