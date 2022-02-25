using BarberShop.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace BarberShop.Domain.Commands
{
    public class SaveClientCommand : Notifiable, ICommand
    {
        public SaveClientCommand()
        { }
        public SaveClientCommand(string firstName, string lastName, string number)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Number = number;

        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Number { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasMinLen(FirstName, 2, "FirstName", "The value FirstName, must have at least 2 char.")
                .HasMaxLen(FirstName, 64, "Firstname", "The value FirstName, must have less than 64 char.")
                .HasMinLen(LastName, 2, "LastName", "The value LastName, must have at least 2 char.")
                .HasMaxLen(LastName, 64, "LastName", "The value LastName, must have less than 64 char.")
                .HasExactLengthIfNotNullOrEmpty(Number, 11, "PhoneNumber", "Phone number must contain 11 char.")
            );
        }
    }
}