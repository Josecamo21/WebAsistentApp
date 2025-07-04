using BusinessLogic;
using Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAsistente.Models;

namespace WebAsistente.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(string user, string password)
        {
            BLLogIn bl = new BLLogIn();
            LogIn logIn = new LogIn(user, password);
            var resultado = await bl.LogIn(logIn);

            if (resultado != null)
                return RedirectToAction("Privacy", "Home");
            else
                return RedirectToAction("Index", "Home");
            
        }
    }
}
