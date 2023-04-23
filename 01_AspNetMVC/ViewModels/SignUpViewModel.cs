using _01_AspNetMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace _01_AspNetMVC.ViewModels
{
    public class SignUpViewModel
    {
        [Display(Name = "First name")]
        [Required(ErrorMessage = "You must enter a first name")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Last name")]
        [Required(ErrorMessage = "You must enter a last name")]
        public string LastName { get; set; } = null!;

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "You must enter a email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Display(Name = "Password")]
        [Required(ErrorMessage = "You have to enter a password")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "You have to confirm your password yo")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "The passwords dont match")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
