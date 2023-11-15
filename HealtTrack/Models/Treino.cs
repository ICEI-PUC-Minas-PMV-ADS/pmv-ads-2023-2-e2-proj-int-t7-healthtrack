using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealtTrack.Models
{
    [Table("Treinos")]
    public class Treino
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        
    }
}

