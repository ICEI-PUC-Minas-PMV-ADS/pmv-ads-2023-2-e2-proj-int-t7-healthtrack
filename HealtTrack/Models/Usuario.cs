using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HealtTrack.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar o usuario!")]
        [Display(Name = "Usuario")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar o Email!")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar a Senha!")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Senha", ErrorMessage = "As senhas não coincidem.")]
        [Display(Name="Confirmar Senha")]
        public string ConfirmarSenha { get; set; }
    }
}
