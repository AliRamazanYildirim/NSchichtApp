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
    public class KategorieDienst : Dienst<Kategorie>, IKategorieDienst
    {
        private readonly IKategorieQuelle _kategorieQuelle;
        private readonly IMapper _mapper;
        public KategorieDienst(IArbeitsEinheit arbeitsEinheit, IGenerischeQuelle<Kategorie> generischeQuelle, IMapper mapper, IKategorieQuelle kategorieQuelle) : base(arbeitsEinheit, generischeQuelle)
        {
            _mapper = mapper;
            _kategorieQuelle = kategorieQuelle;
        }

        public async Task<BenutzerDefinierteAntwortDüo<KategorieMitProduktDüo>> RufEinzigeKategorieZurIDMitProdukteAsync(int KategorieID)
        {
            var kategorie = await _kategorieQuelle.RufEinzigeKategorieZurIDMitProdukteAsync(KategorieID);
            var kategorieDüo = _mapper.Map<KategorieMitProduktDüo>(kategorie);
            return BenutzerDefinierteAntwortDüo<KategorieMitProduktDüo>.Erfolg(200, kategorieDüo);
        }
    }
}
