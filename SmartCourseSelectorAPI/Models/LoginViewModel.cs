namespace SmartCourseSelectorWeb.Models
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // Student or Advisor
    }
}
