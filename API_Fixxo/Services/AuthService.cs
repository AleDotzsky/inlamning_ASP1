using API_Fixxo.Helpers;
using API_Fixxo.Models.DTO;
using API_Fixxo.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace API_Fixxo.Services
{
    public class AuthService
    {
        private readonly UserManager<CustomIdentityUser> _userManager;
        private readonly SignInManager<CustomIdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JwtToken _jwt;

        public AuthService(UserManager<CustomIdentityUser> userManager, SignInManager<CustomIdentityUser> signInManager, RoleManager<IdentityRole> roleManager, JwtToken jwt)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _jwt = jwt;
        }


        public async Task<bool> RegisterAsync(SignUpRequest model)
        {
            if (!await _roleManager.Roles.AnyAsync())
            {
                await _roleManager.CreateAsync(new IdentityRole("admin"));
                await _roleManager.CreateAsync(new IdentityRole("product-manager"));
                await _roleManager.CreateAsync(new IdentityRole("user"));
            }

            var users = await _userManager.Users.CountAsync();

            switch (users)
            {
                case 0:
                    model.RoleName = "admin";
                    break;
                case 1:
                    model.RoleName = "product-manager";
                    break;
                default:
                    model.RoleName = "user";
                    break;
            }

            CustomIdentityUser user = model;

            var result = await _userManager.CreateAsync(user, model.Password);
            if(result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, model.RoleName);

                var isSignedIn = await _signInManager.PasswordSignInAsync(user.Email!, model.Password, false, false);
                if(isSignedIn.Succeeded)
                {
                    return true;
                }
            }
            return false;

        }

        public async Task<string> LoginAsync(SignInRequest model)
        {
            var identityUser = await _userManager.FindByEmailAsync(model.Email);
            if(identityUser != null)
            {
                var signInResult = await _signInManager.CheckPasswordSignInAsync(identityUser, model.Password, false);
                if (signInResult.Succeeded)
                {
                    var roles = await _userManager.GetRolesAsync(identityUser);
                    var claimsIdentity = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("id", identityUser.Id.ToString()),
                        new Claim(ClaimTypes.Name, identityUser.Email!),
                        new Claim(ClaimTypes.Role, roles[0])
                    });
                    return _jwt.Generate(claimsIdentity, DateTime.Now.AddHours(1));
                }
            }

            return string.Empty;
        }

    }
}
