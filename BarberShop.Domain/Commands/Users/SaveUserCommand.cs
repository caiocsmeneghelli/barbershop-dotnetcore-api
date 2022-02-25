using BarberShop.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace BarberShop.Domain.Commands
{
    public class SaveUserCommand : Notifiable, ICommand
    {
        public SaveUserCommand(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
            this.Role = "Admin";

        }
        public SaveUserCommand()
        { }
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
            );
        }
    }
}