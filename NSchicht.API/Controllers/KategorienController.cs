using Microsoft.AspNetCore.Mvc;
using NSchicht.Kern.Dienste;

namespace NSchicht.API.Controllers
{


    public class KategorienController : BenutzerDefinierteBasisController
    {
        private readonly IKategorieDienst _kategorieDienst;

        public KategorienController(IKategorieDienst kategorieDienst)
        {
            _kategorieDienst = kategorieDienst;
        }

        //GET api/produkte/RufEinzigeKategorieZurIDMitProdukte/7
        [HttpGet("[action]")]
        public async Task<IActionResult> RufEinzigeKategorieZurIDMitProdukte(int KategorieID)
        {
            return CreateActionResult(await _kategorieDienst.RufEinzigeKategorieZurIDMitProdukteAsync(KategorieID));
        }
    }
}
