using System;
using BarberShop.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace BarberShop.Domain.Commands.Appointment
{
    public class UpdateDateTimeAppointmentCommand : Notifiable, ICommand
    {
        public UpdateDateTimeAppointmentCommand(string idAppointment, DateTime dateTime)
        {
            IdAppointment = idAppointment;
            DateTime = dateTime;
        }
        public UpdateDateTimeAppointmentCommand()
        { }
        public string IdAppointment { get; set; }
        public DateTime DateTime { get; set; }
        public void Validate()
        {
            var tryParseIdAppointment = Guid.TryParse(IdAppointment, out Guid result);
            if(!tryParseIdAppointment)
                AddNotification(IdAppointment, "Invalid IdAppointment.");
            AddNotifications(
                new Contract()
                    .IsNotNullOrEmpty(DateTime.ToString(), "DateTime", "DateTime cannot be null or empty.")
            );
        }
    }
}