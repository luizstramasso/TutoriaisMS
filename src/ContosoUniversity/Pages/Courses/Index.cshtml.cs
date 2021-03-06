﻿using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesContosoUniversity.Data;
using RazorPagesContosoUniversity.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesContosoUniversity.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly SchoolContext _context;

        public IndexModel(SchoolContext context)
        {
            _context = context;
        }

        public IList<CourseVM> CoursesVM { get; set; }

        public async Task OnGetAsync()
        {
            CoursesVM = await _context.Courses
                .Select(p => new CourseVM
                {
                    CourseID = p.CourseID,
                    Title = p.Title,
                    Credits = p.Credits,
                    DepartmentName = p.Department.Name
                })
                .ToListAsync();
        }
    }
}
