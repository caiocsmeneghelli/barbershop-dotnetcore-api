using BarberShop.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace BarberShop.Domain.Commands.Barbers
{
    public class CreateBarberCommand : Notifiable, ICommand
    {
        public CreateBarberCommand()
        { }
        public CreateBarberCommand(string firstName, string lastName, string email)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;

        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsEmail(Email, "Email", "The value must be a Email.")
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