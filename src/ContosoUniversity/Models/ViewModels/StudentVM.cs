using System;

namespace ContosoUniversity.Models.ViewModels
{
    public class StudentVM
    {
        public int StudentID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}
