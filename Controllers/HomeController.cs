using Microsoft.AspNetCore.Mvc;
using ShoppingOnline.Models;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace ShoppingOnline.Controllers
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
        public IActionResult Donna()
        {
            return View();
        }
        public IActionResult Uomo()
        {
            return View();
        }
        public IActionResult Bambino()
        {
            return View();
        }
        public IActionResult bambina()
        {
            return View();
        }

        public IActionResult Catalogo_Scarpe()
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