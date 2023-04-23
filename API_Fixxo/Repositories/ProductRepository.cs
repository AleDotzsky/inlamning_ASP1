using API_Fixxo.Contexts;
using API_Fixxo.Models.DTO;
using API_Fixxo.Models.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Fixxo.Repositories
{
	public class ProductRepository
	{

		private readonly DataContext _context;


		public ProductRepository(DataContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<ProductHttpResponse>> GetAllProductsAsync()
		{
			var items = await _context.Products.Include(x=> x.Category).ToListAsync();
			var products = new List<ProductHttpResponse>();

			foreach (var item in items)
			{
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

        public async Task<ProductHttpResponse> GetByIdAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == id);

            return product!;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
			try
			{
                var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == id);
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
				return true;
            }
			catch
			{
				return false;
			}
            
        }

        public async Task<ProductHttpResponse> CreateAsync(ProductEntity entity)
		{
			entity.CreatedDate = DateTime.Now;
			_context.Products.Add(entity);
			await _context.SaveChangesAsync();
			return entity;
		}
	}
}
