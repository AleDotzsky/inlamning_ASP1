using API_Fixxo.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Fixxo.Models.DTO
{
	public class ProductHttpResponse
	{
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
	}
}
