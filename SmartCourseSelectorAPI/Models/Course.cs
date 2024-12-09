namespace SmartCourseSelectorWeb.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public bool IsMandatory { get; set; }
        public int Credit { get; set; }
        public string Department { get; set; }

        public int? Quota { get; set; } // NULL olabilir çünkü zorunlu derslerde kullanılmayacak


        // Navigation Properties
        public ICollection<StudentCourseSelection> StudentCourseSelections { get; set; } = new List<StudentCourseSelection>();
    }
}
