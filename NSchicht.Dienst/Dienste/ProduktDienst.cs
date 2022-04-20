using AutoMapper;
using NSchicht.Kern;
using NSchicht.Kern.ArbeitsEinheiten;
using NSchicht.Kern.Dienste;
using NSchicht.Kern.DÜOe;
using NSchicht.Kern.Quellen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSchicht.Dienst.Dienste
{
    public class ProduktDienst : Dienst<Produkt>, IProduktDienst
    {
        private readonly IProduktQuelle _produktQuelle;
        private readonly IMapper _mapper;
        public ProduktDienst(IGenerischeQuelle<Produkt> generischeQuelle, IArbeitsEinheit arbeitsEinheit,  IMapper mapper, IProduktQuelle produktQuelle) : base(arbeitsEinheit, generischeQuelle)
        {
            _mapper = mapper;
            _produktQuelle = produktQuelle;
        }

        public async Task<BenutzerDefinierteAntwortDüo<List<ProduktMitKategorieDüo>>> RufProdukteMitKategorie()
        {
            var produkte=await _produktQuelle.RufProdukteMitKategorie();
            var produkteDüo = _mapper.Map<List<ProduktMitKategorieDüo>>(produkte);
            return BenutzerDefinierteAntwortDüo<List<ProduktMitKategorieDüo>>.Erfolg(200, produkteDüo);
        }
    }
}
