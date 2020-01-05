using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesContosoUniversity.Data;
using RazorPagesContosoUniversity.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesContosoUniversity.Pages
{
    public class AboutModel : PageModel
    {
        private readonly SchoolContext _context;

        public AboutModel(SchoolContext context)
        {
            _context = context;
        }

        public IList<EnrollmentVM> Students { get; set; }
        public async Task OnGetAsync()
        {
            IQueryable<EnrollmentVM> data =
                from student in _context.Students
                group student by student.EnrollmentDate into dateGroup
                select new EnrollmentVM()
                {
                    EnrollmentDate = dateGroup.Key,
                    StudentCount = dateGroup.Count()
                };

            Students = await data.AsNoTracking().ToListAsync();
        }
    }
}