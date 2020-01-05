using System.Collections.Generic;

namespace RazorPagesContosoUniversity.Models.ViewModels
{
    public class InstructorVM
    {
        public IEnumerable<Instructor> Instructors { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; }
    }
}
