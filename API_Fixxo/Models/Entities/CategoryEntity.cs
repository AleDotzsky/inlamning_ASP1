using System.ComponentModel.DataAnnotations;

namespace API_Fixxo.Models.Entities;

public class CategoryEntity
{
	[Key]
	public int CategoryId { get; set; }
	public string CategoryName { get; set; } = null!;

	public ICollection<ProductEntity> Products { get; set; } = new HashSet<ProductEntity>();
}
