using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPages.Data;
using RazorPages.Models;

namespace RazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationContext _context;

        public List<TodoItem> TodoItems { get; set; } = new();

        [BindProperty]
        public TodoItem TodoItem { get; set; } = new();

        public IndexModel(ApplicationContext db)
        {
            _context = db;
        }

        public void OnGet()
        {
            TodoItems = _context.TodoItems.AsNoTracking().ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                _context.TodoItems.Add(TodoItem);
                await _context.SaveChangesAsync();
                return RedirectToPage();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostToggleAsync(int id)
        {
            var item = await _context.TodoItems.FindAsync(id);
            if (item != null)
            {
                item.IsCompleted = !item.IsCompleted;
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var item = await _context.TodoItems.FindAsync(id);
            if (item != null)
            {
                _context.TodoItems.Remove(item);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }
    }
}