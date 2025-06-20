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
       
        public IActionResult  Catalogo_Scarpe()
        {
            string brand = "Nike"; // oppure puoi usare i % 2 per alternare marche
            decimal prezzo = 49.99m;
            string descrizione = "Scarpe da indossare per l'estate e sentirsi più leggera che mai";
          
            var listaScarpa = new List<Scarpa>();

            for (int i = 0; i < 10; i++)
            {
                Scarpa scarpa = new Scarpa
                {
                    Id = i,
                    Brand = brand,
                    Prezzo = prezzo,
                    Descrizione = descrizione,
                    Immagine="/img/image.jpg"
                };

                listaScarpa.Add(scarpa);
            }


            return View(listaScarpa);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}