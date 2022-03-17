using System;
using BarberShop.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace BarberShop.Domain.Commands.Schedule
{
    public class UpdateClientScheduleCommand : Notifiable, ICommand
    {
        public UpdateClientScheduleCommand(Guid idSchedule, Guid idClient)
        {
            IdSchedule = idSchedule;
            IdClient = idClient;
        }
        public UpdateClientScheduleCommand()
        { }
        public Guid IdSchedule { get; set; }
        public Guid IdClient { get; set; }
        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .IsNotNullOrEmpty(IdSchedule.ToString(), "IdSchedule", "Schedule cannot be null or empty.")
                    .IsNotNullOrEmpty(IdClient.ToString(), "IdClient", "Client cannot be null or empty.")
            );
        }
    }
}