using System;
using BarberShop.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace BarberShop.Domain.Commands.Clients
{
    public class UpdateClientCommand : Notifiable, ICommand
    {
        public UpdateClientCommand()
        { }
        public UpdateClientCommand(string id, string firstName, string lastName, string number)
        {
            this.Id = id;
            this.Number = number;

        }
        public string Id {get;set;}
        public string Number { get; set; }

        public void Validate()
        {
            var tryParseId = Guid.TryParse(Id, out Guid tryParseIdResult);
            if(!tryParseId)
                AddNotification(Id, "Id is invalid");
            AddNotifications(
                new Contract()
                .Requires()
                .HasExactLengthIfNotNullOrEmpty(Number, 11, "PhoneNumber", "Phone number must contain 11 char.")
            );
        }
    }
}