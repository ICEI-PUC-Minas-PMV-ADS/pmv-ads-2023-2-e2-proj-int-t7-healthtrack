using System.ComponentModel.DataAnnotations;

namespace HealtTrack.Models
{
    public class FichaDieta
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public List<Dieta> Dietas { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }

    public class Dieta
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Descricao { get; set; }

        public int FichaDietaId { get; set; }
        public FichaDieta FichaDieta { get; set; }
    }
}

