﻿using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesContosoUniversity.Data;
using RazorPagesContosoUniversity.Models;
using RazorPagesContosoUniversity.Models.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesContosoUniversity.Pages.Instructors
{
    public class IndexModel : PageModel
    {
        private readonly SchoolContext _context;

        public IndexModel(SchoolContext context)
        {
            _context = context;
        }

        public InstructorVM InstructorVM { get; set; }
        public int InstructorID { get; set; }
        public int CourseID { get; set; }

        public async Task OnGetAsync(int? id, int? courseID)
        {
            InstructorVM = new InstructorVM();
            InstructorVM.Instructors = await _context.Instructors
                .Include(i => i.OfficeAssignment)
                .Include(i => i.CourseAssignments)
                    .ThenInclude(c => c.Course)
                        .ThenInclude(d => d.Department)
                .OrderBy(l => l.LastName)
                .ToListAsync();

            if (id != null)
            {
                InstructorID = id.Value;
                Instructor instructor = InstructorVM.Instructors
                    .Single(i => i.InstructorID == id.Value);
                InstructorVM.Courses = instructor.CourseAssignments.Select(c => c.Course);
            }

            if (courseID != null)
            {
                CourseID = courseID.Value;
                var selectedCourse = InstructorVM.Courses
                    .Where(c => c.CourseID == courseID).Single();

                await _context.Entry(selectedCourse).Collection(e => e.Enrollments).LoadAsync();

                foreach (Enrollment enrollment in selectedCourse.Enrollments)
                {
                    await _context.Entry(enrollment).Reference(s => s.Student).LoadAsync();
                }

                InstructorVM.Enrollments = selectedCourse.Enrollments;
            }
        }
    }
}
