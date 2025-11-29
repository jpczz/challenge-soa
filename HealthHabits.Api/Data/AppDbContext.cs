using Microsoft.EntityFrameworkCore;
using HealthHabits.Api.Models;

namespace HealthHabits.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Habito> Habitos { get; set; }
        public DbSet<RegistroHabito> RegistrosHabito { get; set; }
    }
}
