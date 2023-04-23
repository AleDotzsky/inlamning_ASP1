using _01_AspNetMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace _01_AspNetMVC.Controllers
{
    public class ProductController : Controller
    {
        public async Task<IActionResult> Index(int productId)
        {
            using var http = new HttpClient();
            var result = await http.GetFromJsonAsync<ProductModel>($"https://localhost:7226/api/products/{productId}?key=bf71372c-99fa-4c3f-9081-8816ce1db322");
            return View(result);
        }
    }
}
