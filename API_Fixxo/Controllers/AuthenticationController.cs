using API_Fixxo.Helpers.Filters;
using API_Fixxo.Models.DTO;
using API_Fixxo.Models.Identity;
using API_Fixxo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API_Fixxo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly AuthService _auth;

        public AuthenticationController(AuthService auth)
        {
            _auth = auth;
        }

        [Route("Register")]
        [HttpPost]
		[UseApiKey]
		public async Task<IActionResult> Register(SignUpRequest model)
        {
            if (ModelState.IsValid)
            {
                if (await _auth.RegisterAsync(model))
                    return Created("", null);
            }

            return BadRequest();
        }

        [Route("Login")]
        [HttpPost]
		[UseApiKey]
		public async Task<IActionResult> Login(SignInRequest model)
        {
            if (ModelState.IsValid)
            {
                var token = await _auth.LoginAsync(model);

                if (!string.IsNullOrEmpty(token))
                    return Ok(token);
            }

            return Unauthorized("Incorrect email or password");
        }
    }
}
