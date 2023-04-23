using API_Fixxo.Contexts;
using API_Fixxo.Models.DTO;
using API_Fixxo.Models.Entities;

namespace API_Fixxo.Repositories
{
	public class ContactRepository
	{

		private readonly DataContext _context;

		public ContactRepository(DataContext context)
		{
			_context = context;
		}

		public async Task<ContactHttpResponse> SaveContactAsync(ContactEntity entity)
		{
			_context.Comments.Add(entity);
			await _context.SaveChangesAsync();
			return entity;
		}
	}
}
