using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NSchicht.Kern;
using NSchicht.Kern.Dienste;
using NSchicht.Kern.DÜOe;
using NSchicht.Web.Dienste;

namespace NSchicht.Web.Controllers
{
    public class ProdukteController : Controller
    {
        private readonly ProduktApiDienst _produktApiDienst;
        private readonly KategorieApiDienst _kategorieApiDienst;

        public ProdukteController(KategorieApiDienst kategorieApiDienst, ProduktApiDienst produktApiDienst)
        {
            _kategorieApiDienst = kategorieApiDienst;
            _produktApiDienst = produktApiDienst;
        }

        public async Task<IActionResult> Index()
        {
            
            return View((await _produktApiDienst.RufProdukteMitKategorie()));
        }
        public async Task<IActionResult> Speichern()
        {
            var kategorienDüo = await _kategorieApiDienst.GehZurAlleDatenAsync();
            ViewBag.kategorien = new SelectList(kategorienDüo, "ID", "Name");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Speichern(ProduktDüo produktDüo)

        {
            if (ModelState.IsValid)
            {

                await _produktApiDienst.SpeichernAsync(produktDüo);
                return RedirectToAction(nameof(Index));
            }
            await _produktApiDienst.SpeichernAsync(produktDüo);
            return RedirectToAction(nameof(Index));
            
        }
        [ServiceFilter(typeof(FilterNichtGefunden<Produkt>))]
        public async Task<IActionResult>Aktualisieren(int ID)
        {
            var produkt = await _produktApiDienst.GehZurIDAsync(ID);
            var kategorienDüo = await _kategorieApiDienst.GehZurAlleDatenAsync();
            ViewBag.kategorien = new SelectList(kategorienDüo, "ID", "Name",produkt.KategorieID);
            return View(produkt);

        }
        [HttpPost]
        public async Task<IActionResult> Aktualisieren(ProduktDüo produktDüo)

        {
            if (ModelState.IsValid)
            {

                await _produktApiDienst.AktualisierenAsync(produktDüo);
                return RedirectToAction(nameof(Index));
            }
            var kategorienDüo = await _kategorieApiDienst.GehZurAlleDatenAsync();
            ViewBag.kategorien = new SelectList(kategorienDüo, "ID", "Name", produktDüo.KategorieID);
            return View(produktDüo);
        }
        public async Task<IActionResult> Entfernen(int ID)
        {
            
            await _produktApiDienst.EntfernenAsync(ID);
            return RedirectToAction(nameof(Index));
        }
    }
}
