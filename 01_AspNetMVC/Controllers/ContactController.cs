using Microsoft.AspNetCore.Mvc;
using _01_AspNetMVC.ViewModels;
using System.Net.Http.Headers;

namespace _01_AspNetMVC.Controllers
{
    public class ContactController : Controller
	{


        public IActionResult Index()
        {


            if (TempData.ContainsKey("Submit"))
            {
                ViewBag.Submit = TempData["Submit"];
            }
            return View();
        }

        [HttpPost]
		public async Task<IActionResult> Index(ContactViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
                using var http = new HttpClient();
                var token = HttpContext.Request.Cookies["accessToken"];
                http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var result = await http.PostAsJsonAsync("https://localhost:7226/api/Contact?key=bf71372c-99fa-4c3f-9081-8816ce1db322", viewModel);
                if(result.IsSuccessStatusCode)
                {
                    ModelState.Clear();
                    TempData["Submit"] = true;
                    return RedirectToAction(nameof(Index));
                }

                return BadRequest(result);

            }

            return View(viewModel);
        }
    }
}