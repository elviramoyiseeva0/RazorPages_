using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorRages_2.Models;

namespace RazorRages_2.Pages
{
    public class SubjectsModel : PageModel
    {
        [BindProperty]
        public List<Subject> Subjects { get; set; } = new();

        public bool IsSubmitted { get; set; } = false;

        public void OnGet()
        {
        }

        public void OnPost()
        {
            IsSubmitted = true;
        }
    }
}
