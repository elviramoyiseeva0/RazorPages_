using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPages.Data;
using RazorPages.Models;

namespace RazorPages.Pages.Todo
{
    public class EditModel : PageModel
    {
        private readonly ApplicationContext _context;

        [BindProperty]
        public TodoItem TodoItem { get; set; } = new();

        public EditModel(ApplicationContext db)
        {
            _context = db;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var item = await _context.TodoItems.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            TodoItem = item;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Attach(TodoItem).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.TodoItems.Any(e => e.Id == TodoItem.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToPage("../Index");
        }
    }
}