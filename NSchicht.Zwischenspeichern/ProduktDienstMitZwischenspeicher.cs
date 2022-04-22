using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using NSchicht.Dienst.Ausnahmen;
using NSchicht.Kern;
using NSchicht.Kern.ArbeitsEinheiten;
using NSchicht.Kern.Dienste;
using NSchicht.Kern.DÜOe;
using NSchicht.Kern.Quellen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NSchicht.Zwischenspeichern
{
    public class ProduktDienstMitZwischenspeicher : IProduktDienst
    {
        private const string ZwischenspeicherProduktSchlüssel = "produkteZwischenspeicher";
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly IProduktQuelle _produktQuelle;
        private readonly IArbeitsEinheit _arbeitsEinheit;

        public ProduktDienstMitZwischenspeicher(IArbeitsEinheit arbeitsEinheit, IProduktQuelle produktQuelle, IMemoryCache memoryCache, IMapper mapper)
        {
            _arbeitsEinheit = arbeitsEinheit;
            _produktQuelle = produktQuelle;
            _memoryCache = memoryCache;
            _mapper = mapper;

            if(!_memoryCache.TryGetValue(ZwischenspeicherProduktSchlüssel, out _))
            {

                _memoryCache.Set(ZwischenspeicherProduktSchlüssel, _produktQuelle.RufProdukteMitKategorie().Result);
               
            }
        }

        public async Task AktualisierenAsync(Produkt einheit)
        {
            _produktQuelle.Aktualisieren(einheit);
            await _arbeitsEinheit.VerpflichtenAsync();
            await ZwischenspeicherAlleProdukteAsync();
        }

        public async Task EntfernenAsync(Produkt einheit)
        {
            _produktQuelle.Entfernen(einheit);
            await _arbeitsEinheit.VerpflichtenAsync();
            await ZwischenspeicherAlleProdukteAsync();
        }

        public async Task EntfernenFeldAsync(IEnumerable<Produkt> einheiten)
        {
            _produktQuelle.EntfernenFeld(einheiten);
            await _arbeitsEinheit.VerpflichtenAsync();
            await ZwischenspeicherAlleProdukteAsync();
        }

        public Task<IEnumerable<Produkt>> GehZurAlleDatenAsync()
        {
            var produkte = _memoryCache.Get<IEnumerable<Produkt>>(ZwischenspeicherProduktSchlüssel);
            return Task.FromResult(produkte);
        }

        public Task<Produkt> GehZurIDAsync(int ID)
        {
            var produkt = _memoryCache.Get<List<Produkt>>(ZwischenspeicherProduktSchlüssel).FirstOrDefault(x => x.ID==ID);
            if (produkt == null)
            {
                throw new AusnahmeNichtGefunden($"{typeof(Produkt).Name}({ID}) wurde nicht gefunden");
            }
            return Task.FromResult(produkt);
        }

        public async Task<Produkt> InsertAsync(Produkt einheit)
        {
            await _produktQuelle.InsertAsync(einheit);
            await _arbeitsEinheit.VerpflichtenAsync();
            await ZwischenspeicherAlleProdukteAsync();
            return einheit;
        }

        public async Task<IEnumerable<Produkt>> InsertFeldAsync(IEnumerable<Produkt> einheiten)
        {
            await _produktQuelle.InsertFeldAsync(einheiten);
            await _arbeitsEinheit.VerpflichtenAsync();
            await ZwischenspeicherAlleProdukteAsync();
            return einheiten;
        }

        public Task<bool> IrgendeinAsync(Expression<Func<Produkt, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public  Task<BenutzerDefinierteAntwortDüo<List<ProduktMitKategorieDüo>>> RufProdukteMitKategorie()
        {
            var produkte = _memoryCache.Get<IEnumerable<Produkt>>(ZwischenspeicherProduktSchlüssel);
           

            var produkteMitKategorieDüo = _mapper.Map<List<ProduktMitKategorieDüo>>(produkte);

            return Task.FromResult(BenutzerDefinierteAntwortDüo<List<ProduktMitKategorieDüo>>.Erfolg(200, produkteMitKategorieDüo));
            

        }

        public IQueryable<Produkt> Wo(Expression<Func<Produkt, bool>> expression)
        {
            return _memoryCache.Get<List<Produkt>>(ZwischenspeicherProduktSchlüssel).Where(expression.Compile()).AsQueryable();
        }

        public async Task ZwischenspeicherAlleProdukteAsync()
        {
            _memoryCache.Set(ZwischenspeicherProduktSchlüssel, await _produktQuelle.GehZurAlleDaten().ToListAsync());

        }
    }
}
