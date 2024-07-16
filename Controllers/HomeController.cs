using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestCaptcha.Models;

namespace TestCaptcha.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Route("login")]
        public async Task<IActionResult> Login(string? returnUrl)
        {
            return View();
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(Login signin, string? returnUrl)
        {
            if (signin.RecaptchaToken == null)
            {
                ModelState.AddModelError("", "Captcha Not Valid");
                return View(signin);
            }

            if (ModelState.IsValid)
            {
                //var UserInDb = _userManager.FindByEmailAsync(signin.Email);
                /*if (UserInDb != null && !UserInDb.EmailConfirmed && (!await _userManager.CheckPasswordAsync(await UserInDb, signin.Password)))
                {
                    ModelState.AddModelError("", "Email Not Confirmed Yet");
                    return View(signin);
                }*/
            }
            

            signin.ReturnUrl = returnUrl;
            return View(signin);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
