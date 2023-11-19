using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealtTrack.Models;

[Authorize]
public class FichaDietaController : Controller
{
    private readonly AppDbContext _context;

    public FichaDietaController(AppDbContext context)
    {
        _context = context;
    }

    // GET: FichaTreino
    public async Task<IActionResult> Index()
    {
        var userId = GetUserIdd();
        var fichasDieta = await _context.FichasDieta
            .Where(ft => ft.UserId == userId)
            .ToListAsync();

        return View(fichasDieta);
    }

    // GET: FichaTreino/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var fichasDieta = await _context.FichasDieta
            .Include(ft => ft.Dietas)
            .FirstOrDefaultAsync(m => m.Id == id && m.UserId == GetUserIdd());
        if (fichasDieta == null)
        {
            return NotFound();
        }

        return View(fichasDieta);
    }

    // GET: FichaTreino/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: FichaTreino/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nome")] FichaDieta fichasDieta)
    {
        if (ModelState.IsValid)
        {
            fichasDieta.UserId = GetUserIdd();
            _context.Add(fichasDieta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(fichasDieta);
    }

    // GET: FichaTreino/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var fichaDieta = await _context.FichasDieta.FindAsync(id);
        if (fichaDieta == null || fichaDieta.UserId != GetUserIdd())
        {
            return NotFound();
        }
        return View(fichaDieta);
    }


    // POST: FichaTreino/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] FichaDieta fichasDieta)
    {
        if (id != fichasDieta.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(fichasDieta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FichaDietaExists(fichasDieta.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }
        return View(fichasDieta);
    }

    // GET: FichaTreino/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var fichasDieta = await _context.FichasDieta
            .FirstOrDefaultAsync(m => m.Id == id && m.UserId == GetUserIdd());
        if (fichasDieta == null)
        {
            return NotFound();
        }

        return View(fichasDieta);
    }

    // POST: FichaTreino/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var fichasDieta = await _context.FichasDieta.FindAsync(id);
        _context.FichasDieta.Remove(fichasDieta);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool FichaDietaExists(int id)
    {
        return _context.FichasDieta.Any(e => e.Id == id && e.UserId == GetUserIdd());
    }

    private string GetUserIdd()
    {
        return User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
    }
}
