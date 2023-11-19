using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HealtTrack.Models;

[Authorize]
public class DietaController : Controller
{
    private readonly AppDbContext _context;

    public DietaController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Create(int fichaDietaId)
    {
        ViewBag.FichaDietaId = fichaDietaId;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,FichaDietaId")] Dieta dieta)
    {
        if (ModelState.IsValid)
        {
            _context.Add(dieta);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "FichaDieta", new { id = dieta.FichaDietaId });
        }
        return View(dieta);
    }
}
