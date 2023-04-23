using _01_AspNetMVC.Models;
using _01_AspNetMVC.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace _01_AspNetMVC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            using var http = new HttpClient();

            var token = HttpContext.Request.Cookies["accessToken"];
            http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            try
            {
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                var readableToken = handler.ReadJwtToken(token);
                var roles = readableToken.Claims.Where(x => x.Type == "role").Select(x => x.Value).ToList();
                if (roles.Contains("admin") || roles.Contains("product-manager"))
                {
                    return RedirectToAction("Admin", "Admin");
                }
                return RedirectToAction("NormalUser", "Admin");
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Admin(ProductViewModel viewModel)
        {
            using var http = new HttpClient();
            var token = HttpContext.Request.Cookies["accessToken"];
            http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            var readableToken = handler.ReadJwtToken(token);
            var roles = readableToken.Claims.Where(x => x.Type == "role").Select(x => x.Value).ToList();

            if (roles.Contains("user"))
            {
                return RedirectToAction("NormalUser", "Admin");
            }

            if (ModelState.IsValid)
            {
                using var httpClient = new HttpClient();
                var result = await httpClient.PostAsJsonAsync("https://localhost:7226/api/Products?key=bf71372c-99fa-4c3f-9081-8816ce1db322", viewModel);
            }
			
			return View();
        }

        public async Task<IActionResult> AdminDelete(int productId)
        {
            using var http = new HttpClient();
            var token = HttpContext.Request.Cookies["accessToken"];
            http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            var readableToken = handler.ReadJwtToken(token);
            var roles = readableToken.Claims.Where(x => x.Type == "role").Select(x => x.Value).ToList();

            if (roles.Contains("user"))
            {
                return RedirectToAction("NormalUser", "Admin");
            }

			using var httpProducts = new HttpClient();
            if(productId != 0)
            {
				await httpProducts.PostAsJsonAsync($"https://localhost:7226/api/Products/delete/{productId}?key=bf71372c-99fa-4c3f-9081-8816ce1db322", productId);
				return RedirectToAction("AdminDelete", "Admin");
			}
			var result = await httpProducts.GetFromJsonAsync<IEnumerable<ProductModel>>("https://localhost:7226/api/products?key=bf71372c-99fa-4c3f-9081-8816ce1db322");
			return View(result);
		}

		public IActionResult NormalUser()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
