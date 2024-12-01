using System.ComponentModel.DataAnnotations;

namespace SmartCourseSelectorWeb.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
