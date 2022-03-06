using BarberShop.Domain.Entities;

namespace BarberShop.Domain.Models
{
    public class User : Entity
    {
        public User(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
        }
        public User()
        {  }
        public string UserName { get; private set; }
        public string Password { get; private set; }

        public void ChangePassword(string password)
        {
            Password = password;
        }
    }
}