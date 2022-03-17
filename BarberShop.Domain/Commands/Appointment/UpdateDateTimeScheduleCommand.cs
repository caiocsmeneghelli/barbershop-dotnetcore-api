using System;
using BarberShop.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace BarberShop.Domain.Commands.Appointment
{
    public class UpdateDateTimeAppointmentCommand : Notifiable, ICommand
    {
        public UpdateDateTimeAppointmentCommand(Guid idAppointment, DateTime dateTime)
        {
            IdAppointment = idAppointment;
            DateTime = dateTime;
        }
        public UpdateDateTimeAppointmentCommand()
        { }
        public Guid IdAppointment { get; set; }
        public DateTime DateTime { get; set; }
        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .IsNotNullOrEmpty(IdAppointment.ToString(), "IdAppointment", "Appointment cannot be null or empty.")
                    .IsNotNullOrEmpty(DateTime.ToString(), "DateTime", "DateTime cannot be null or empty.")
            );
        }
    }
}