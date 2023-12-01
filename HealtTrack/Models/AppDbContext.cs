using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HealtTrack.Models;

namespace HealtTrack.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) {}

        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }

        public DbSet<FichaTreino> FichasTreino { get; set; }
        public DbSet<Exercicio> Exercicios { get; set; }

        public DbSet<FichaDieta> FichasDieta { get; set; }
        public DbSet<Dieta> Dietas { get; set; }

        

    }
}
