using System;
using BarberShop.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace BarberShop.Domain.Commands.Schedule
{
    public class UpdateBarberScheduleCommand : Notifiable, ICommand
    {
        public UpdateBarberScheduleCommand(Guid idSchedule, Guid idBarber)
        {
            IdSchedule = idSchedule;
            IdBarber = idBarber;
        }
        public UpdateBarberScheduleCommand()
        { }
        public Guid IdSchedule { get; set; }
        public Guid IdBarber { get; set; }
        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .IsNotNullOrEmpty(IdSchedule.ToString(), "IdSchedule", "Schedule cannot be null or empty.")
                    .IsNotNullOrEmpty(IdBarber.ToString(), "IdBarber", "Barber cannot be null or empty.")
            );
        }
    }
}