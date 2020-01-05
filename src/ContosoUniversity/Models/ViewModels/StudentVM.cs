using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesContosoUniversity.Models.ViewModels
{
    public class StudentVM
    {
        public int StudentID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }
    }
}
