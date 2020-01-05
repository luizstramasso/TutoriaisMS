using Microsoft.AspNetCore.Mvc;
using RazorPagesContosoUniversity.Data;
using RazorPagesContosoUniversity.Models;
using System.Threading.Tasks;

namespace RazorPagesContosoUniversity.Pages.Courses
{
    public class CreateModel : _DepartmentPM
    {
        private readonly SchoolContext _context;

        public CreateModel(SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateDepartmentDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Course Course { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyCourse = new Course();

            if (await TryUpdateModelAsync<Course>(
                emptyCourse, "course", c => c.CourseID, c => c.DepartmentID, c => c.Title, c => c.Credits))
            {
                _context.Courses.Add(emptyCourse);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateDepartmentDropDownList(_context, emptyCourse.DepartmentID);
            return Page();
        }
    }
}
