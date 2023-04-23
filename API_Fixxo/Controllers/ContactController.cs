using API_Fixxo.Helpers.Filters;
using API_Fixxo.Models.DTO;
using API_Fixxo.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Fixxo.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactController : ControllerBase
	{
		private readonly ContactRepository _contactRepo;

		public ContactController(ContactRepository contactRepo)
		{
			_contactRepo = contactRepo;
		}

		[HttpPost]
		[UseApiKey]
		public async Task<IActionResult> SaveContactAsync(ContactHttpRequest req)
		{
			if (ModelState.IsValid)
			{
				var contact = await _contactRepo.SaveContactAsync(req);

				if (contact != null)
				{
					return Created("", contact);
				}
			}

			return BadRequest();
		}
	}
}
