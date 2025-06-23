using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingOnline.Data;
using ShoppingOnline.Models;


namespace ShoppingOnline.Controllers
{
    public class ScarpeController : Controller
    {
        private readonly ShoppingOnlineContext Context;
        public ScarpeController(ShoppingOnlineContext context)
        {
            this.Context = context;
        }
        
        public async Task<IActionResult> Index()
        {
            var scarpe=await Context.CatalogoScarpe.ToListAsync();
            return View(scarpe);
        }
        
        public async Task<IActionResult> Dettaglio(int id)
        {
            var scarpa=await Context.CatalogoScarpe.FindAsync(id);
            if(scarpa == null)
            {
                return NotFound();
            }
            else
            {
                 return View(scarpa);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Search(string? TestoDaCercare) {  
            if (string.IsNullOrWhiteSpace(TestoDaCercare))
            {
                return View(new List<CatalogoScarpe>()); 
            }

            var Nuovalista = await Context.CatalogoScarpe
                .Where(s =>(( s.Nome != null || s.Marca!=null || s.Descrizione!=null) 
                    && ((s.Nome.ToLower().Contains(TestoDaCercare.ToLower()))
                    || s.Marca.ToLower().Contains(TestoDaCercare.ToLower()) 
                    || s.Descrizione.ToLower().Contains(TestoDaCercare.ToLower()))))
                .ToListAsync();

            if (Nuovalista.Count == 0)
            {
                RedirectToAction("EmptyResult","Scarpe");
            }

            return View(Nuovalista);
        }
        [HttpGet]
        public async Task<IActionResult> EmptyResult()
        {
            return View();
        }

    }
}
