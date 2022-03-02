using System;
using BarberShop.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace BarberShop.Domain.Commands.Users
{
    public class UpdateUserCommand : Notifiable, ICommand
    {
        
        public UpdateUserCommand()
        { }

        public UpdateUserCommand(Guid id, string password)
        {
            Id = id;
            Password = password;
        }

        public Guid Id { get; set; }
        public string Password { get; set; }
        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Password, 6, "Password", "The value Password, must have more than 6 char.")
                    .HasMaxLen(Password, 32, "Password", "The value Password, must have less than 32 char.")
            );
        }
    }
}