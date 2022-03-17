using System;
using BarberShop.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace BarberShop.Domain.Commands.Schedule
{
    public class UpdateDateTimeScheduleCommand : Notifiable, ICommand
    {
        public UpdateDateTimeScheduleCommand(Guid idSchedule, DateTime dateTime)
        {
            IdSchedule = idSchedule;
            DateTime = dateTime;
        }
        public UpdateDateTimeScheduleCommand()
        { }
        public Guid IdSchedule { get; set; }
        public DateTime DateTime { get; set; }
        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .IsNotNullOrEmpty(IdSchedule.ToString(), "IdSchedule", "Schedule cannot be null or empty.")
                    .IsNotNullOrEmpty(DateTime.ToString(), "DateTime", "DateTime cannot be null or empty.")
            );
        }
    }
}