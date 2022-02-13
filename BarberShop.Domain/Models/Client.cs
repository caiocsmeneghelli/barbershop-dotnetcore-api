using BarberShop.Domain.Entities;

namespace BarberShop.Domain.Models
{
    public class Client : Entity
    {
        public Client(string name, string lastName, string phone)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Phone = phone;

        }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Phone { get; private set; }
    }
}