using API_Fixxo.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_Fixxo.Contexts
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions options) : base(options)
		{

		}

		public DbSet<ProductEntity> Products { get; set; }
		public DbSet<CategoryEntity> Categories { get; set; }
	}
}
