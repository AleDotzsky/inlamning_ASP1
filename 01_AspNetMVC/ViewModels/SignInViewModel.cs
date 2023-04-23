using System.ComponentModel.DataAnnotations;

namespace _01_AspNetMVC.ViewModels
{
    public class SignInViewModel
    {
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "You must enter a email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Display(Name = "Password")]
        [Required(ErrorMessage = "You have to enter a password")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
