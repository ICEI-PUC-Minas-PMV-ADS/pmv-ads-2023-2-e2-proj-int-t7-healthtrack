using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HealtTrack.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }




        // Adicione propriedades personalizadas se necessário
        //public string Name { get; internal set; }

        public List<FichaTreino> FichasTreino { get; set; }

    }

    public class TodoItem
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public bool IsDone { get; set; }


        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public async Task DeleteAsync(AppDbContext dbContext)
        {
            // Certifique-se de que o item a ser excluído está conectado ao contexto
            if (Id != 0)
            {
                dbContext.Entry(this).State = EntityState.Deleted;
                await dbContext.SaveChangesAsync();
            }
        }

        

    }
}
