using System;
using BarberShop.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace BarberShop.Domain.Commands.Barbers{
    public class UpdateBarberCommand : Notifiable, ICommand
    {
        public UpdateBarberCommand()
        {
        }

        public UpdateBarberCommand(string id, string firstName, string lastName, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public void Validate()
        {
            var tryParseId = Guid.TryParse(Id, out Guid tryParseIdResult);
            if(!tryParseId)
                AddNotification(Id,"Id invalid.");
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Email, 6, "Email", "The value Email, must have more than 6 char.")
                    .HasMaxLen(Email, 64, "Email", "The value Email, must have less than 64 char.")
                    .HasMinLen(FirstName, 2, "FirstName", "The value FirstName, must have at least 2 char.")
                    .HasMaxLen(FirstName, 64, "Firstname", "The value FirstName, must have less than 64 char.")
                    .HasMinLen(LastName, 2, "LastName", "The value LastName, must have at least 2 char.")
                    .HasMaxLen(LastName, 64, "LastName", "The value LastName, must have less than 64 char.")
            );
        }
    }
}