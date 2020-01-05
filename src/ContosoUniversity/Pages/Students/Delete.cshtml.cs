﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesContosoUniversity.Data;
using RazorPagesContosoUniversity.Models;
using System.Threading.Tasks;

namespace RazorPagesContosoUniversity.Pages.Students
{
    public class DeleteModel : PageModel
    {
        private readonly SchoolContext _context;

        public DeleteModel(SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; }
        public string ErrorMessage { get; set; }
        public bool? saveChangesError { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
                return NotFound();

            Student = await _context.Students
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.StudentID == id);

            if (Student == null)
                return NotFound();

            if (saveChangesError.GetValueOrDefault())
                ErrorMessage = "Delete failed. Try again";

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
                return NotFound();

            var student = await _context.Students.FindAsync(id);

            if (student == null)
                return NotFound();

            try
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            catch (DbUpdateException)
            {
                return RedirectToAction("./Delete", new { id, saveChangesError = true });
            }
        }
    }
}
