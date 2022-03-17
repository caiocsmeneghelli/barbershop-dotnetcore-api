using System;
using BarberShop.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace BarberShop.Domain.Commands.Appointment
{
    public class UpdateBarberAppointmentCommand : Notifiable, ICommand
    {
        public UpdateBarberAppointmentCommand(string idAppointment, string idBarber)
        {
            IdAppointment = idAppointment;
            IdBarber = idBarber;
        }
        public UpdateBarberAppointmentCommand()
        { }
        public string IdAppointment { get; set; }
        public string IdBarber { get; set; }
        public void Validate()
        {
            var tryParseIdAppointment = Guid.TryParse(IdAppointment, out Guid resultAppointment);
            if(!tryParseIdAppointment)
                AddNotification(IdAppointment, "Invalid IdAppointment.");
            var tryParseIdBarber = Guid.TryParse(IdBarber, out Guid resultBarber);
            if(!tryParseIdBarber)
                AddNotification(IdBarber, "Invalid IdBarber.");
        }
    }
}