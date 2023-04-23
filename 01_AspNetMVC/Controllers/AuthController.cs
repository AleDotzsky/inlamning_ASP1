using _01_AspNetMVC.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _01_AspNetMVC.Controllers
{
    public class AuthController : Controller
    {


        public IActionResult Signup()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Signup(SignUpViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                using var http = new HttpClient();
                var result = await http.PostAsJsonAsync("https://localhost:7226/api/Authentication/Register?key=bf71372c-99fa-4c3f-9081-8816ce1db322", viewModel);
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Login", "Auth");
                }
                return BadRequest(result);
            }

            return View(viewModel);

        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(SignInViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                using var http = new HttpClient();
                var result = await http.PostAsJsonAsync("https://localhost:7226/api/Authentication/Login?key=bf71372c-99fa-4c3f-9081-8816ce1db322", viewModel);
                var token = await result.Content.ReadAsStringAsync();


                HttpContext.Response.Cookies.Append("accessToken", token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    Expires = DateTime.Now.AddHours(1)
                });

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Incorrect email or password");

            return View(viewModel);
        }
    }
}
