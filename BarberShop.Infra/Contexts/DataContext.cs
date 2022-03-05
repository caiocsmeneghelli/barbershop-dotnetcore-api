using BarberShop.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {}

        public DbSet<Client> Clients { get; set; }
    }
}