namespace _01_AspNetMVC.Models
{
	public class CategoryModel
	{
		public int ProductId { get; set; }
		public string CategoryName { get; set; } = null!;

		public ICollection<ProductModel> Products { get; set; } = new HashSet<ProductModel>();
	}
}
