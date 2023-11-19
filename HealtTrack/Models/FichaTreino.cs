using System.ComponentModel.DataAnnotations;

namespace HealtTrack.Models
{
    public class FichaTreino
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public List<Exercicio> Exercicios { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }

    public class Exercicio
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Descricao { get; set; }

        public int FichaTreinoId { get; set; }
        public FichaTreino FichaTreino { get; set; }
    }
}

