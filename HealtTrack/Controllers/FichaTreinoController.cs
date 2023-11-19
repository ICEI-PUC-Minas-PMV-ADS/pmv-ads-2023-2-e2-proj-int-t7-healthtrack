// Controllers/FichaTreinoController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealtTrack.Models;

[Authorize]
public class FichaTreinoController : Controller
{
    private readonly AppDbContext _context;

    public FichaTreinoController(AppDbContext context)
    {
        _context = context;
    }

    // GET: FichaTreino
    public async Task<IActionResult> Index()
    {
        var userId = GetUserIdd();
        var fichasTreino = await _context.FichasTreino
            .Where(ft => ft.UserId == userId)
            .ToListAsync();

        return View(fichasTreino);
    }

    // GET: FichaTreino/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var fichaTreino = await _context.FichasTreino
            .Include(ft => ft.Exercicios)
            .FirstOrDefaultAsync(m => m.Id == id && m.UserId == GetUserIdd());
        if (fichaTreino == null)
        {
            return NotFound();
        }

        return View(fichaTreino);
    }

    // GET: FichaTreino/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: FichaTreino/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nome")] FichaTreino fichaTreino)
    {
        if (ModelState.IsValid)
        {
            fichaTreino.UserId = GetUserIdd();
            _context.Add(fichaTreino);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(fichaTreino);
    }

    // GET: FichaTreino/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var fichaTreino = await _context.FichasTreino.FindAsync(id);
        if (fichaTreino == null || fichaTreino.UserId != GetUserIdd())
        {
            return NotFound();
        }
        return View(fichaTreino);
    }

    // POST: FichaTreino/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] FichaTreino fichaTreino)
    {
        if (id != fichaTreino.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(fichaTreino);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FichaTreinoExists(fichaTreino.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }
        return View(fichaTreino);
    }

    // GET: FichaTreino/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var fichaTreino = await _context.FichasTreino
            .FirstOrDefaultAsync(m => m.Id == id && m.UserId == GetUserIdd());
        if (fichaTreino == null)
        {
            return NotFound();
        }

        return View(fichaTreino);
    }

    // POST: FichaTreino/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var fichaTreino = await _context.FichasTreino.FindAsync(id);
        _context.FichasTreino.Remove(fichaTreino);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool FichaTreinoExists(int id)
    {
        return _context.FichasTreino.Any(e => e.Id == id && e.UserId == GetUserIdd());
    }

    private string GetUserIdd()
    {
        return User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
    }
}
