using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesContosoUniversity.Models.ViewModels
{
    public class EnrollmentVM
    {
        [DataType(DataType.Date)]
        [Display(Name = "Enrollment Date")]
        public DateTime? EnrollmentDate { get; set; }
        public int StudentCount { get; set; }
    }
}
