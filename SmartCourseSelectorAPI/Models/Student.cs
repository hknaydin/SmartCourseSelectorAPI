namespace SmartCourseSelectorWeb.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int? AdvisorID { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string Department { get; set; } // Yeni eklenen özellik

        // Navigation Properties
        public Advisor Advisor { get; set; } // Danışman bilgisi için eklendi

        // Navigation Properties
        public ICollection<StudentCourseSelection> StudentCourseSelections { get; set; } = new List<StudentCourseSelection>();
    }
}
