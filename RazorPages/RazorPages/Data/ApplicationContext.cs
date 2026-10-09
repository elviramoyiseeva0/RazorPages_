using RazorPages.Models;
using Microsoft.EntityFrameworkCore;

namespace RazorPages.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
