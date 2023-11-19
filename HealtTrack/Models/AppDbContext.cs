using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using HealtTrack.Models;

namespace HealtTrack.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Treino> Treinos { get; set; }
        public DbSet<HealtTrack.Models.Videos> Videos { get; set; }

    }
}
