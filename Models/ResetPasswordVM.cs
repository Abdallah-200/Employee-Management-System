using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Models
{
    public class ResetPasswordVM
    {
        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "Enter your valid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Not Matching")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
        public string Token { get; set; }
    }
}
