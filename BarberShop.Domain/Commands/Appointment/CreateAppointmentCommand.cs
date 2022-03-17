using System;
using BarberShop.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace BarberShop.Domain.Commands.Appointment
{
    public class CreateAppointmentCommand : Notifiable, ICommand
    {
        public string IdBarber { get; set; }
        public string IdClient { get; set; }
        public DateTime DateTime { get; set; }
        public CreateAppointmentCommand()
        { }

        public CreateAppointmentCommand(string idBarber, string idClient, DateTime dateTime)
        {
            IdBarber = idBarber;
            IdClient = idClient;
            DateTime = dateTime;
        }

        public void Validate()
        {
            var tryParseIdBarber = Guid.TryParse(IdBarber, out Guid resultBarber);
            var tryParseIdClient = Guid.TryParse(IdClient, out Guid resultClient);
            if(!tryParseIdBarber)
                AddNotification(IdBarber, "Invalid IdBarber.");
            if(!tryParseIdClient)
                AddNotification(IdClient, "Invalid IdClient.");

            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(DateTime.ToString(), "DateTime", "DateTime cannot be null")
            );
        }
    }
}