// Models/EditProfileViewModel.cs
using System;
using System.ComponentModel.DataAnnotations;

public class EditProfileViewModel
{
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }

    public string Gender { get; set; }
    
    [Display(Name = "Altura (cm)")]
    public double Height { get; set; }
    
    [Display(Name = "Peso (kg)")]
    public double Weight { get; set; }

    // Adicione outras propriedades conforme necessário
}
