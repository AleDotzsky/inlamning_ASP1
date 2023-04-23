using System.ComponentModel.DataAnnotations;

namespace _01_AspNetMVC.ViewModels
{
    public class ProductViewModel
    {
        [Display(Name = "Title")]
        [Required(ErrorMessage = "You must enter a title")]
        public string Title { get; set; } = null!;

        [Display(Name = "Description")]
        [Required(ErrorMessage = "You must enter a description")]
        public string Description { get; set; } = null!;

        [Display(Name = "Rating")]
        [Required(ErrorMessage = "You must enter a rating")]
        public int Rating { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "You must enter a price")]
        public decimal Price { get; set; }

        [Display(Name = "Image url")]
        [Required(ErrorMessage = "You must enter a image url")]
        public string ImageUrl { get; set; } = null!;

        [Display(Name = "Tag")]
        [Required(ErrorMessage = "You must enter a tag")]
        public string Tag { get; set; } = null!;

        [Display(Name = "Category")]
        [Required(ErrorMessage = "You must enter a category")]
        public int CategoryId { get; set; }
    }
}
