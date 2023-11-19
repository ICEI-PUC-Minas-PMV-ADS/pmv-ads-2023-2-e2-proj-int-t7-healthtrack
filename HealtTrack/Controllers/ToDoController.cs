// Controllers/TodoController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using HealtTrack.Models;

[Authorize]
public class TodoController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly AppDbContext _context;

    public TodoController(UserManager<ApplicationUser> userManager, AppDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }
    
    public IActionResult Index()
    {
        var user = _userManager.GetUserAsync(User).Result;
        var todoItems = _context.TodoItems.Where(item => item.UserId == user.Id).ToList();
        var viewModel = new TodoItemViewModel { TodoItems = todoItems };
        return View(viewModel);
    }



    [HttpPost]
    public IActionResult AddTodoItem(TodoItemViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = _userManager.GetUserAsync(User).Result;

            var todoItem = new TodoItem
            {
                Description = model.Descricao,
                IsDone = model.Concluido,
                UserId = user.Id
            };

            _context.TodoItems.Add(todoItem);
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> DeleteTodoItem(int id)
    {
        var todoItem = await _context.TodoItems.FindAsync(id);

        if (todoItem == null)
        {
            return NotFound();
        }

        await todoItem.DeleteAsync(_context);

        return RedirectToAction("Index");
    }

}
