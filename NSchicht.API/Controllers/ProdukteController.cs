using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSchicht.Kern;
using NSchicht.Kern.Dienste;
using NSchicht.Kern.DÜOe;

namespace NSchicht.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdukteController : BenutzerDefinierteBasisController
    {
        private readonly IMapper _mapper;
        private readonly IDienst<Produkt> _dienst;
        private readonly IProduktDienst _produktDienst;

        public ProdukteController(IDienst<Produkt> dienst, IMapper mapper, IProduktDienst produktDienst)
        {
            _dienst = dienst;
            _mapper = mapper;
            _produktDienst = produktDienst;
        }
        ////GET api/produkte/RufProdukteMitKategorie
        [HttpGet("[action]")]
        public async Task<IActionResult> RufProdukteMitKategorie()
        {
            return CreateActionResult(await _produktDienst.RufProdukteMitKategorie());
        }


        //GET api/produkte
        [HttpGet]
        public async Task<IActionResult>Alle()
        {
            var produkte=await _dienst.GehZurAlleDatenAsync();
            var produkteDüoe = _mapper.Map<List<ProduktDüo>>(produkte.ToList());
            return CreateActionResult(BenutzerDefinierteAntwortDüo<List<ProduktDüo>>.Erfolg(200, produkteDüoe));
        }
        //GET api/produkte/7
        [HttpGet("{ID}")]
        public async Task<IActionResult> GehZurID(int ID)
        {
            var produkt = await _dienst.GehZurIDAsync(ID);
            var produkteDüo = _mapper.Map<ProduktDüo>(produkt);
            return CreateActionResult(BenutzerDefinierteAntwortDüo<ProduktDüo>.Erfolg(200, produkteDüo));
        }
        [HttpPost]
        public async Task<IActionResult> Speichern(ProduktDüo produktDüo)
        {
            var produkt = await _dienst.InsertAsync(_mapper.Map<Produkt>(produktDüo));
            var produkteDüo = _mapper.Map<ProduktDüo>(produkt);
            return CreateActionResult(BenutzerDefinierteAntwortDüo<ProduktDüo>.Erfolg(201, produkteDüo));
        }
        [HttpPut]
        public async Task<IActionResult> Aktualisieren(ProduktAktualisierenDüo produktDüo)
        {
            await _dienst.AktualisierenAsync(_mapper.Map<Produkt>(produktDüo));
            return CreateActionResult(BenutzerDefinierteAntwortDüo<KeinInhaltDüo>.Erfolg(204));
        }
        [HttpDelete("{ID}")]
        public async Task<IActionResult> Entfernen(int ID)
        {
            var produkt = await _dienst.GehZurIDAsync(ID);
             await _dienst.EntfernenAsync(produkt);
            return CreateActionResult(BenutzerDefinierteAntwortDüo<KeinInhaltDüo>.Erfolg(204));
        }
    }
}
