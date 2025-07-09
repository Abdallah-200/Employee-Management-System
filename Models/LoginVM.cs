using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "Enter your valid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
