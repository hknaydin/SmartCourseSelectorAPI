namespace SmartCourseSelectorWeb.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public int? RelatedID { get; set; }
        public string Email { get; set; } // Email alanını ekleyin

    }
}
