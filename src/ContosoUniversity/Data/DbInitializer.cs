using ContosoUniversity.Models;
using ContosoUniversity.Models.Enums;
using System;
using System.Linq;

namespace ContosoUniversity.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            //context.Database.EnsureCreated();

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
                new Student{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("01/09/2019")},
                new Student{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("01/09/2017")},
                new Student{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("01/09/2018")},
                new Student{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("01/09/2017")},
                new Student{FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("01/09/2017")},
                new Student{FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("01/09/2016")},
                new Student{FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("01/09/2018")},
                new Student{FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("01/09/2019")}
            };
            foreach (Student student in students)
            {
                context.Students.Add(student);
            }
            context.SaveChanges();

            var instructors = new Instructor[]
            {
                new Instructor { FirstMidName = "Kim", LastName = "Abercrombie", HireDate = DateTime.Parse("11/03/1995") },
                new Instructor { FirstMidName = "Fadi", LastName = "Fakhouri", HireDate = DateTime.Parse("06/07/2002") },
                new Instructor { FirstMidName = "Roger", LastName = "Harui", HireDate = DateTime.Parse("01/07/1998") },
                new Instructor { FirstMidName = "Candece", LastName = "Kapoor", HireDate = DateTime.Parse("15/01/2001") },
                new Instructor { FirstMidName = "Roger", LastName = "Zheng", HireDate = DateTime.Parse("12/02/2004") }
            };
            foreach (Instructor instructor in instructors)
            {
                context.Instructors.Add(instructor);
            }
            context.SaveChanges();

            var departments = new Department[]
            {
                new Department { Name = "English", Budget = 350000, StartDate = DateTime.Parse("01/09/2007"),
                    InstructorID = instructors.Single(i => i.LastName == "Abercrombie").InstructorID},
                new Department { Name = "Mathematics", Budget = 100000, StartDate = DateTime.Parse("01/09/2007"),
                    InstructorID = instructors.Single(i => i.LastName == "Fakhouri").InstructorID},
                new Department { Name = "Engineering", Budget = 350000, StartDate = DateTime.Parse("01/09/2007"),
                    InstructorID = instructors.Single(i => i.LastName == "Harui").InstructorID},
                new Department { Name = "Economics", Budget = 100000, StartDate = DateTime.Parse("01/09/2007"),
                    InstructorID = instructors.Single(i => i.LastName == "Kapoor").InstructorID}
            };
            foreach (Department department in departments)
            {
                context.Departments.Add(department);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course{ CourseID = 1050, Title="Chemistry",Credits=3,
                    DepartmentID = departments.Single(d => d.Name == "Engineering").DepartmentID },
                new Course{ CourseID  = 4022, Title="Microeconomics",Credits=3,
                    DepartmentID = departments.Single(d => d.Name == "Economics").DepartmentID},
                new Course{ CourseID = 4041, Title="Macroeconomics",Credits=3,
                    DepartmentID = departments.Single(d => d.Name == "Economics").DepartmentID},
                new Course{ CourseID = 1045,Title="Calculus",Credits=4,
                    DepartmentID = departments.Single(d => d.Name == "Mathematics").DepartmentID},
                new Course{ CourseID = 3141, Title="Trigonometry",Credits=4,
                    DepartmentID = departments.Single(d => d.Name == "Mathematics").DepartmentID},
                new Course{ CourseID = 2021, Title="Composition",Credits=3,
                    DepartmentID = departments.Single(d => d.Name == "English").DepartmentID},
                new Course{ CourseID = 2042, Title="Literature",Credits=4,
                    DepartmentID = departments.Single(d => d.Name == "English").DepartmentID}
            };
            foreach (Course course in courses)
            {
                context.Courses.Add(course);
            }
            context.SaveChanges();

            var officeAssignments = new OfficeAssignment[]
            {
                new OfficeAssignment { InstructorID = instructors.Single(i => i.LastName == "Fakhouri").InstructorID, Location = "Smith 17"},
                new OfficeAssignment { InstructorID = instructors.Single(i => i.LastName == "Harui").InstructorID, Location = "Gowan 27"},
                new OfficeAssignment { InstructorID = instructors.Single(i => i.LastName == "Kapoor").InstructorID, Location = "Thompson 304"}
            };
            foreach (OfficeAssignment officeAssignment in officeAssignments)
            {
                context.OfficeAssignments.Add(officeAssignment);
            }
            context.SaveChanges();

            var courseInstructors = new CourseAssignment[]
            {
                new CourseAssignment { CourseID = courses.Single(c => c.Title == "Chemistry").CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Kapoor").InstructorID},
                new CourseAssignment { CourseID = courses.Single(c => c.Title == "Chemistry").CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Harui").InstructorID},
                new CourseAssignment { CourseID = courses.Single(c => c.Title == "Macroeconomics").CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Zheng").InstructorID},
                new CourseAssignment { CourseID = courses.Single(c => c.Title == "Calculus").CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Fakhouri").InstructorID},
                new CourseAssignment { CourseID = courses.Single(c => c.Title == "Trigonometry").CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Harui").InstructorID},
                new CourseAssignment { CourseID = courses.Single(c => c.Title == "Composition").CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Abercrombie").InstructorID},
                new CourseAssignment { CourseID = courses.Single(c => c.Title == "Literature").CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Abercrombie").InstructorID}
            };
            foreach (CourseAssignment courseAssignment in courseInstructors)
            {
                context.CourseAssignments.Add(courseAssignment);
            };
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment { StudentID = students.Single(s => s.LastName == "Alexander").StudentID,
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,Grade = Grade.A},
                new Enrollment {StudentID = students.Single(s => s.LastName == "Alexander").StudentID,
                    CourseID = courses.Single(c => c.Title == "Macroeconomics" ).CourseID,Grade = Grade.C},
                new Enrollment {StudentID = students.Single(s => s.LastName == "Alexander").StudentID,
                    CourseID = courses.Single(c => c.Title == "Macroeconomics" ).CourseID,Grade = Grade.B},
                new Enrollment {StudentID = students.Single(s => s.LastName == "Alonso").StudentID,
                    CourseID = courses.Single(c => c.Title == "Calculus" ).CourseID,Grade = Grade.B},
                new Enrollment {StudentID = students.Single(s => s.LastName == "Alonso").StudentID,
                    CourseID = courses.Single(c => c.Title == "Trigonometry" ).CourseID,Grade = Grade.B},
                new Enrollment {StudentID = students.Single(s => s.LastName == "Alonso").StudentID,
                    CourseID = courses.Single(c => c.Title == "Composition" ).CourseID,Grade = Grade.B},
                new Enrollment {StudentID = students.Single(s => s.LastName == "Anand").StudentID,
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID},
                new Enrollment {StudentID = students.Single(s => s.LastName == "Anand").StudentID,
                    CourseID = courses.Single(c => c.Title == "Macroeconomics").CourseID,Grade = Grade.B},
                new Enrollment {StudentID = students.Single(s => s.LastName == "Barzdukas").StudentID,
                    CourseID = courses.Single(c => c.Title == "Chemistry").CourseID,Grade = Grade.B},
                new Enrollment {StudentID = students.Single(s => s.LastName == "Li").StudentID,
                    CourseID = courses.Single(c => c.Title == "Composition").CourseID,Grade = Grade.B},
                new Enrollment {StudentID = students.Single(s => s.LastName == "Justice").StudentID,
                    CourseID = courses.Single(c => c.Title == "Literature").CourseID,Grade = Grade.B}
            };
            foreach (Enrollment enrollment in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(s => s.Student.StudentID == enrollment.StudentID &&
                                                                          s.Course.CourseID == enrollment.CourseID)
                                                              .SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(enrollment);
                }
            }
            context.SaveChanges();
        }
    }
}