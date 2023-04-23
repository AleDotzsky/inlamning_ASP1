using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace _01_AspNetMVC.ViewModels
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "You must enter a name")]
        [MinLength(2, ErrorMessage = "The firstname must contain atleast two characters")]
        [DisplayName("Firstname")]
        public string Name { get; set; } = null!;

        [EmailAddress]
        [Required(ErrorMessage = "You must enter a email-address")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "E-mail must have the format a@a.aa")]
        [DisplayName("E-postadress")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "You must enter a comment")]
        [MinLength(10, ErrorMessage = "The firstname must contain atleast ten characters")]
        [DisplayName("Comment")]
        public string Comment { get; set; } = null!;


    }
}
