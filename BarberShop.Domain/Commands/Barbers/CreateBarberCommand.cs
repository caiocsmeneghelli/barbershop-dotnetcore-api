using BarberShop.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace BarberShop.Domain.Commands.Barbers
{
    public class CreateBarberCommand : Notifiable, ICommand
    {
        public CreateBarberCommand()
        { }
        public CreateBarberCommand(string firstName, string lastName, string email, string userName, string password)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.UserName = userName;
            this.Password = password;
            this.Role = "Barber";

        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(UserName, 4, "UserName", "The value Username, must have more than 3 char.")
                    .HasMaxLen(UserName, 32, "UserName", "The value Username, must have less than 20 char.")
                    .HasMinLen(Password, 6, "Password", "The value Password, must have more than 6 char.")
                    .HasMaxLen(Password, 32, "Password", "The value Password, must have less than 32 char.")
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