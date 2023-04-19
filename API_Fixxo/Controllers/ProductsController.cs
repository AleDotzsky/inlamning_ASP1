using API_Fixxo.Models.DTO;
using API_Fixxo.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Fixxo.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly ProductRepository _productRepo;
		private readonly CategoryRepository _categoryRepo;

		public ProductsController(ProductRepository productRepo, CategoryRepository categoryRepo)
		{
			_productRepo = productRepo;
			_categoryRepo = categoryRepo;
		}


		[HttpGet]
		public async Task<IActionResult> GetAllProductsAsync()
		{
			var products = await _productRepo.GetAllProductsAsync();
			return Ok(products);
		}

		[HttpGet("tag/{tagName}")]
		public async Task<IActionResult> GetByTagAsync(string tagName)
		{
			return Ok(await _productRepo.GetByTagAsync(tagName));
		}

		[HttpPost]
		public async Task<IActionResult> CreateAsync(ProductHttpRequest req)
		{
			if(ModelState.IsValid)
			{
				var product = await _productRepo.CreateAsync(req);

				if (product != null)
				{
					return Created("", product);
				}
			}

			return BadRequest();

		}
	}
}