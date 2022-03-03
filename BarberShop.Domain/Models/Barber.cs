using BarberShop.Domain.Entities;

namespace BarberShop.Domain.Models
{
    public class Barber : User
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public Barber()
        { }
        public Barber(string firstName, string lastName, string email, string userName, string password, string role)
        : base(userName, password, role)
        {
            FirstName = firstName;
            LastName = lastName;
            email = Email;
            role = "Barber";
        }

        public void UpdateEmail(string email)
        {
            Email = email;
        }
        public void UpdateName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}