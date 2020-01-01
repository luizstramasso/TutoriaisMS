using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models.ViewModels
{
    public class CourseVM
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }

    }
}
