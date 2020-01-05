using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesContosoUniversity.Data;
using System.Linq;

namespace RazorPagesContosoUniversity.Pages.Courses
{
    public class _DepartmentPM : PageModel
    {
        public SelectList DepartmentSL { get; set; }

        public void PopulateDepartmentDropDownList(SchoolContext _context, object selectedDepartment = null)
        {
            var departmentsQuery = from d in _context.Departments
                                   orderby d.Name
                                   select d;

            DepartmentSL = new SelectList(departmentsQuery.AsNoTracking(), "DepartmentID", "Name", selectedDepartment);
        }
    }
}
