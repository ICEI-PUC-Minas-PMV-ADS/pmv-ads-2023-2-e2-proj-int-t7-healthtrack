using System.ComponentModel.DataAnnotations;

namespace HealtTrack.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Obrigatorio informar o email! ")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar a senha! ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
