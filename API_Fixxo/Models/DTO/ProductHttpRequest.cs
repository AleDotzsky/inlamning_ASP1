using API_Fixxo.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Fixxo.Models.DTO
{
	public class ProductHttpRequest
	{
		public string Title { get; set; } = null!;
		public string? Description { get; set; }
		public int Rating { get; set; }

		[Column(TypeName = "money")]
		public decimal Price { get; set; }
		public string ImageUrl { get; set; } = null!;
		public string Tag { get; set; } = null!;

		public int CategoryId { get; set; }

		public static implicit operator ProductEntity(ProductHttpRequest request)
		{
			return new ProductEntity
			{
				Title = request.Title,
				Description = request.Description,
				Rating = request.Rating,
				Price = request.Price,
				ImageUrl = request.ImageUrl,
				Tag = request.Tag,
				CategoryId = request.CategoryId,
			};
		}
	}
}
