using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_AspNetMVC.Models
{
	public class ProductModel
	{
		public int ProductId { get; set; }
		public string Title { get; set; } = null!;
		public string? Description { get; set; }
		public int Rating { get; set; }
		public decimal Price { get; set; }
		public string ImageUrl { get; set; } = null!;
		public string Tag { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public int CategoryId { get; set; }
		public CategoryModel Category { get; set; } = null!;
	}
}
