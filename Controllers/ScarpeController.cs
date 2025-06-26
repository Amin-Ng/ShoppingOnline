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
            var scarpe = await Context.CatalogoScarpe.ToListAsync();
            return View(scarpe);
        }

        /* public async Task<IActionResult> Dettaglio(int id)
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
         }*/
        [HttpGet]
        public async Task<IActionResult> Search(string? TestoDaCercare)
        {
            if (string.IsNullOrWhiteSpace(TestoDaCercare))
            {
                return View(new List<CatalogoScarpe>());
            }

            var Nuovalista = await Context.CatalogoScarpe
                .Where(s =>
                    (s.Nome != null && s.Nome.ToLower().Contains(TestoDaCercare.ToLower())) ||
                    (s.Marca != null && s.Marca.ToLower().Contains(TestoDaCercare.ToLower())) ||
                    (s.Descrizione != null && s.Descrizione.ToLower().Contains(TestoDaCercare.ToLower()))
                )
                .ToListAsync();

            if (Nuovalista.Count == 0)
            {
                return RedirectToAction("EmptyResult", "Scarpe");
            }

            return View(Nuovalista);
        }

        [HttpGet]
        public IActionResult EmptyResult()
        {
            return View(new List<CatalogoScarpe>());
        }

        public async Task<IActionResult> Dettaglio(int id)
        {
            var IdScarpa = await Context.CatalogoScarpe
                .Include(s => s.tagliaScarpa) // include la relazione
                .FirstOrDefaultAsync(s => s.Id == id);

            if (IdScarpa == null)
            {
                return RedirectToAction("EmptyResult");
            }

            var taglieDisponibili = IdScarpa.tagliaScarpa ?? new List<TagliaScarpa>();

            var ListaProposte = await Context.CatalogoScarpe
                .Where(s => s.Id != id)
                .Take(4)
                .ToListAsync();

            var model = new DettaglioScarpaViewModel
            {
                Scarpa = IdScarpa,
                AltreProposte = ListaProposte,
                TaglieDisponibili = taglieDisponibili
            };

            return View(model);
        }

    }
}
