// Controllers/ProfileController.cs

// Importe outros namespaces necessários
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using HealtTrack.Models;

[Authorize]
public class ProfileController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;

    public ProfileController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        ApplicationUser user = await _userManager.GetUserAsync(User);

        if (user == null)
        {
            return NotFound();
        }

        // Mapeie as propriedades do ApplicationUser para o ProfileViewModel
        ProfileViewModel profileViewModel = new ProfileViewModel
        {
            Name = user.Name,
            DateOfBirth = user.DateOfBirth,
            Gender = user.Gender,
            Height = user.Height,
            Weight = user.Weight
            // Adicione outras propriedades conforme necessário
        };

        return View(profileViewModel);
    }

    [HttpGet]
    public async Task<IActionResult> Edit()
    {
        ApplicationUser user = await _userManager.GetUserAsync(User);

        if (user == null)
        {
            return NotFound();
        }

        // Mapeie as propriedades do ApplicationUser para o EditProfileViewModel
        EditProfileViewModel editProfileViewModel = new EditProfileViewModel
        {
            DateOfBirth = user.DateOfBirth,
            Gender = user.Gender,
            Height = user.Height,
            Weight = user.Weight
            // Adicione outras propriedades conforme necessário
        };

        return View(editProfileViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(EditProfileViewModel model)
    {
        if (ModelState.IsValid)
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound();
            }

            // Atualize as propriedades do ApplicationUser com base no modelo editado
            user.DateOfBirth = model.DateOfBirth;
            user.Gender = model.Gender;
            user.Height = model.Height;
            user.Weight = model.Weight;
            // Atualize outras propriedades conforme necessário

            // Salve as alterações no banco de dados
            await _userManager.UpdateAsync(user);

            return RedirectToAction("Index");
        }

        // Se o modelo não for válido, retorne à view de edição com erros
        return View(model);
    }
}
