using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NSchicht.Kern;
using NSchicht.Kern.Dienste;
using NSchicht.Kern.DÜOe;

namespace NSchicht.Web.Controllers
{
    public class ProdukteController : Controller
    {
        private readonly IProduktDienst _produktDienst;
        private readonly IKategorieDienst _kategorieDienst;
        private readonly IMapper _mapper;
        public ProdukteController(IProduktDienst produktDienst, IKategorieDienst kategorieDienst, IMapper mapper)
        {
            _produktDienst = produktDienst;
            _kategorieDienst = kategorieDienst;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index()
        {
            
            return View(await _produktDienst.RufProdukteMitKategorie());
        }
        public async Task<IActionResult> Speichern()
        {
            var kategorien = await _kategorieDienst.GehZurAlleDatenAsync();
            var kategorienDüoe = _mapper.Map<List<KategorieDüo>>(kategorien.ToList());
            ViewBag.kategorien = new SelectList(kategorienDüoe, "ID", "Name");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Speichern(ProduktDüo produktDüo)

        {
            if (ModelState.IsValid)
            {

                await _produktDienst.InsertAsync(_mapper.Map<Produkt>(produktDüo));
                return RedirectToAction(nameof(Index));
            }
            var kategorien = await _kategorieDienst.GehZurAlleDatenAsync();
            var kategorienDüoe = _mapper.Map<List<KategorieDüo>>(kategorien.ToList());
            ViewBag.kategorien = new SelectList(kategorienDüoe, "ID", "Name");
            return View();
        }

    }
}
