using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NSchicht.Kern.Dienste;
using NSchicht.Kern.DÜOe;

namespace NSchicht.API.Controllers
{


    public class KategorienController : BenutzerDefinierteBasisController
    {
        private readonly IKategorieDienst _kategorieDienst;
        private readonly IMapper _mapper;

        public KategorienController(IKategorieDienst kategorieDienst, IMapper mapper)
        {
            _kategorieDienst = kategorieDienst;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GehZurAlleDaten()
        {

            var kategorien = await _kategorieDienst.GehZurAlleDatenAsync();

            var kategorienDüo = _mapper.Map<List<KategorieDüo>>(kategorien.ToList());

            return CreateActionResult(BenutzerDefinierteAntwortDüo<List<KategorieDüo>>.Erfolg(200, kategorienDüo));

        }

        //GET api/produkte/RufEinzigeKategorieZurIDMitProdukte/7
        [HttpGet("[action]")]
        public async Task<IActionResult> RufEinzigeKategorieZurIDMitProdukte(int KategorieID)
        {
            return CreateActionResult(await _kategorieDienst.RufEinzigeKategorieZurIDMitProdukteAsync(KategorieID));
        }
    }
}
