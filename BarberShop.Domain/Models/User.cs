using BarberShop.Domain.Entities;

namespace BarberShop.Domain.Models
{
    public class User : Entity
    {
        public User(string userName, string password, string role)
        {
            this.UserName = userName;
            this.Password = password;
            this.Role = role;
        }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }

    }
}