// Models/RegisterViewModel.cs
using System.ComponentModel.DataAnnotations;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Obrigatorio informar o nome! ")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Obrigatorio informar email! ")]
    [EmailAddress]
    public string Email { get; set; }

    [Required(ErrorMessage = "Obrigatorio informar a senha! ")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required(ErrorMessage = "Obrigatorio confirmar a senha! ")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "As senhas não coincidem.")]
    public string ConfirmarSenha { get; set; }
}
