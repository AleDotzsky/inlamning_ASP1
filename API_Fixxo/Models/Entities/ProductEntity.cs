using API_Fixxo.Models.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_Fixxo.Models.Entities
{
	public class ProductEntity
	{
        [Key]
        public int ProductId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public int Rating { get; set; }

        [Column(TypeName = "money")]
		public decimal Price { get; set; }
        public string ImageUrl { get; set; } = null!;
        public string Tag { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; } = null!;

        public static implicit operator ProductHttpResponse(ProductEntity entity)
        {
            return new ProductHttpResponse
            {
				ProductId = entity.ProductId,
                Title = entity.Title,
                Description = entity.Description,
                Rating = entity.Rating,
                Price = entity.Price,
                ImageUrl = entity.ImageUrl,
                Tag = entity.Tag,
                CreatedDate = entity.CreatedDate,
                CategoryId = entity.CategoryId,
                Category = entity.Category,
            };
        }
    }
}
