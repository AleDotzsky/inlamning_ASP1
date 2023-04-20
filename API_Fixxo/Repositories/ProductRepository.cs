using API_Fixxo.Contexts;
using API_Fixxo.Models.DTO;
using API_Fixxo.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_Fixxo.Repositories
{
	public class ProductRepository
	{

		private readonly DataContext _context;
		private readonly CategoryRepository _categoryRepo;


		public ProductRepository(DataContext context, CategoryRepository categoryRepo)
		{
			_context = context;
			_categoryRepo = categoryRepo;
		}

		public async Task<IEnumerable<ProductHttpResponse>> GetAllProductsAsync()
		{
			var items = await _context.Products.Include(x=> x.Category).ToListAsync();
			//var categories = await _context.Categories.ToListAsync();
			var products = new List<ProductHttpResponse>();

			foreach (var item in items)
			{
				//var category = categories.FirstOrDefault(c => c.CategoryId == item.CategoryId);
				//item.Category = category!;
				products.Add(item);
			}

			return products;
		}

		public async Task<IEnumerable<ProductHttpResponse>> GetByTagAsync(string tag)
		{
			var items = await _context.Products.Where(x => x.Tag == tag).ToListAsync();
			var products = new List<ProductHttpResponse>();

			foreach (var item in items)
			{
				products.Add(item);
			}

			return products;
		}

		public async Task<ProductHttpResponse> CreateAsync(ProductEntity entity)
		{
			_context.Products.Add(entity);
			await _context.SaveChangesAsync();
			return entity;
		}
	}
}
