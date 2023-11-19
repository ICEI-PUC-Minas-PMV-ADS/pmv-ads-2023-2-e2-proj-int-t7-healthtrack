// Controllers/ExercicioController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HealtTrack.Models;

[Authorize]
public class ExercicioController : Controller
{
    private readonly AppDbContext _context;

    public ExercicioController(AppDbContext context)
    {
        _context = context;
    }

    // GET: Exercicio/Create
    public IActionResult Create(int fichaTreinoId)
    {
        ViewBag.FichaTreinoId = fichaTreinoId;
        return View();
    }

    // POST: Exercicio/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,FichaTreinoId")] Exercicio exercicio)
    {
        if (ModelState.IsValid)
        {
            _context.Add(exercicio);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "FichaTreino", new { id = exercicio.FichaTreinoId });
        }
        return View(exercicio);
    }
}
