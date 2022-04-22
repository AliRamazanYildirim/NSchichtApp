using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NSchicht.API.Filter;
using NSchicht.Kern;
using NSchicht.Kern.Dienste;
using NSchicht.Kern.DÜOe;

namespace NSchicht.API.Controllers
{


    public class ProdukteController : BenutzerDefinierteBasisController
    {
        private readonly IMapper _mapper;
        
        private readonly IProduktDienst _produktDienst;
        public ProdukteController(IDienst<Produkt> dienst, IMapper mapper, IProduktDienst produktDienst)
        {
            
            _mapper = mapper;
            _produktDienst = produktDienst;
        }

        //GET api/produkte/RufProdukteMitKategorie
        [HttpGet("[action]")]
        public async Task<IActionResult> RufProdukteMitKategorie()
        {
            return CreateActionResult(await _produktDienst.RufProdukteMitKategorie());
        }

        //GET api/produkte
        [HttpGet]
        public async Task<IActionResult>Alle()
        {
            var produkte=await _produktDienst.GehZurAlleDatenAsync();
            var produkteDüoe = _mapper.Map<List<ProduktDüo>>(produkte.ToList());
            return CreateActionResult(BenutzerDefinierteAntwortDüo<List<ProduktDüo>>.Erfolg(200, produkteDüoe));
        }
        [ServiceFilter(typeof(FilterNichtGefunden<Produkt>))]
        //GET api/produkte/7
        [HttpGet("{ID}")]
        public async Task<IActionResult> GehZurID(int ID)
        {
            var produkt = await _produktDienst.GehZurIDAsync(ID);
            var produkteDüo = _mapper.Map<ProduktDüo>(produkt);
            return CreateActionResult(BenutzerDefinierteAntwortDüo<ProduktDüo>.Erfolg(200, produkteDüo));
        }
        [HttpPost]
        public async Task<IActionResult> Speichern(ProduktDüo produktDüo)
        {
            var produkt = await _produktDienst.InsertAsync(_mapper.Map<Produkt>(produktDüo));
            var produkteDüo = _mapper.Map<ProduktDüo>(produkt);
            return CreateActionResult(BenutzerDefinierteAntwortDüo<ProduktDüo>.Erfolg(201, produkteDüo));
        }
        [HttpPut]
        public async Task<IActionResult> Aktualisieren(ProduktAktualisierenDüo produktDüo)
        {
            await _produktDienst.AktualisierenAsync(_mapper.Map<Produkt>(produktDüo));
            return CreateActionResult(BenutzerDefinierteAntwortDüo<KeinInhaltDüo>.Erfolg(204));
        }
        [ServiceFilter(typeof(FilterNichtGefunden<Produkt>))]
        [HttpDelete("{ID}")]
        public async Task<IActionResult> Entfernen(int ID)
        {
            var produkt = await _produktDienst.GehZurIDAsync(ID);
             await _produktDienst.EntfernenAsync(produkt);
            return CreateActionResult(BenutzerDefinierteAntwortDüo<KeinInhaltDüo>.Erfolg(204));
        }
    }
}
