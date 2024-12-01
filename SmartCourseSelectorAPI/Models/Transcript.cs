namespace SmartCourseSelectorWeb.Models
{
    public class Transcript
    {
        public int TranscriptID { get; set; } // Primary Key
        public int StudentID { get; set; } // Foreign Key: Öğrenci ID
        public int CourseID { get; set; } // Foreign Key: Ders ID
        public string Grade { get; set; } // Harf Notu (AA, BA, vs.)
        public string Semester { get; set; } // Dönem (Örn: 2024-2025 Güz)

        // Navigation Properties
        public Student Student { get; set; } // Öğrenci
        public Course Course { get; set; } // Ders
    }
}
