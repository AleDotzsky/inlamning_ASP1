using API_Fixxo.Contexts;
using API_Fixxo.Models.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace API_Fixxo.Repositories
{
	public class CategoryRepository
	{
		private readonly DataContext _context;

		public CategoryRepository(DataContext context)
		{
			_context = context;
		}

		public async Task<CategoryEntity?> GetByIdAsync(int id)
		{
			return await _context.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.CategoryId == id);
		}

		public async Task<IEnumerable<CategoryEntity>> GetAllCategoriesAsync()
		{
			return await _context.Categories.ToListAsync();
		}
	}
}
