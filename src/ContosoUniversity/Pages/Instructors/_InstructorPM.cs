using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesContosoUniversity.Data;
using RazorPagesContosoUniversity.Models;
using RazorPagesContosoUniversity.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace RazorPagesContosoUniversity.Pages.Instructors
{
    public class _InstructorPM : PageModel
    {
        public IList<AssignmentVM> AssignedList;

        public void PopulateAssignedCourseData(SchoolContext context, Instructor instructor)
        {
            var allCourses = context.Courses;
            var instructorCourses = new HashSet<int>(
                instructor.CourseAssignments.Select(c => c.CourseID));
            AssignedList = new List<AssignmentVM>();

            foreach (var course in allCourses)
            {
                AssignedList.Add(new AssignmentVM
                {
                    CourseID = course.CourseID,
                    Title = course.Title,
                    Assigned = instructorCourses.Contains(course.CourseID)
                });
            }
        }

        public void UpdateInstructorCourse(SchoolContext context, string[] selectedCourses, Instructor instructorToUpdate)
        {
            if (selectedCourses == null)
            {
                instructorToUpdate.CourseAssignments = new List<CourseAssignment>();
                return;
            }

            var selectedCoursesHS = new HashSet<string>(selectedCourses);
            var instructorCourses = new HashSet<int>(instructorToUpdate.CourseAssignments.Select(c => c.Course.CourseID));

            foreach (var courses in context.Courses)
            {
                if (selectedCoursesHS.Contains(courses.CourseID.ToString()))
                {
                    if (!instructorCourses.Contains(courses.CourseID))
                    {
                        instructorToUpdate.CourseAssignments.Add(
                            new CourseAssignment
                            {
                                InstructorID = instructorToUpdate.InstructorID,
                                CourseID = courses.CourseID
                            });
                    }
                }
                else
                {
                    if (instructorCourses.Contains(courses.CourseID))
                    {
                        CourseAssignment courseToRemove =
                            instructorToUpdate
                            .CourseAssignments
                            .SingleOrDefault(
                                i => i.CourseID == courses.CourseID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
