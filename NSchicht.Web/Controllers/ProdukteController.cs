using Microsoft.AspNetCore.Mvc;
using NSchicht.Kern.Dienste;

namespace NSchicht.Web.Controllers
{
    public class ProdukteController : Controller
    {
        private readonly IProduktDienst _produktDienst;

        public ProdukteController(IProduktDienst produktDienst)
        {
            _produktDienst = produktDienst;
        }

        
        public async Task<IActionResult> Index()
        {
            
            return View(await _produktDienst.RufProdukteMitKategorie());
        }
    }
}
