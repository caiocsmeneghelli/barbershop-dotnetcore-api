using BarberShop.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Barber> Barbers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}