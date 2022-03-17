using System;
using BarberShop.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace BarberShop.Domain.Commands.Appointment
{
    public class UpdateBarberAppointmentCommand : Notifiable, ICommand
    {
        public UpdateBarberAppointmentCommand(Guid idAppointment, Guid idBarber)
        {
            IdAppointment = idAppointment;
            IdBarber = idBarber;
        }
        public UpdateBarberAppointmentCommand()
        { }
        public Guid IdAppointment { get; set; }
        public Guid IdBarber { get; set; }
        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .IsNotNullOrEmpty(IdAppointment.ToString(), "IdAppointment", "Appointment cannot be null or empty.")
                    .IsNotNullOrEmpty(IdBarber.ToString(), "IdBarber", "Barber cannot be null or empty.")
            );
        }
    }
}