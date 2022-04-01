using System;
using BarberShop.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace BarberShop.Domain.Commands.Barbers
{
    public class ChangePasswordBarberCommand : Notifiable, ICommand
    {
        public ChangePasswordBarberCommand(string id, string password)
        {
            Id = id;
            Password = password;
        }

        public string Id { get; set; }
        public string Password { get; set; }

        public void Validate()
        {
            var tryParseId = Guid.TryParse(Id, out Guid tryParseIdResult);
            if(!tryParseId)
                AddNotification(Id, "Invalid Id.");
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Password, 6, "Password", "The value Password, must have more than 6 char.")
                    .HasMaxLen(Password, 32, "Password", "The value Password, must have less than 32 char.")
            );
        }
    }
}