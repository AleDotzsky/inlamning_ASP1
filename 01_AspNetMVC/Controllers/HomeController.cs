using _01_AspNetMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace _01_AspNetMVC.Controllers;

public class HomeController : Controller
{
    public async Task<IActionResult> Index()
    {
        //using var http = new HttpClient();
        //var result = await http.GetFromJsonAsync<IEnumerable<ProductModel>>("https://localhost:7226/api/products");
        return View();
    }
}
