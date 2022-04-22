using NSchicht.Kern.DÜOe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSchicht.Kern.Dienste
{
    public interface IKategorieDienst:IDienst<Kategorie>
    {
        public Task<BenutzerDefinierteAntwortDüo<KategorieMitProduktDüo>> RufEinzigeKategorieZurIDMitProdukteAsync(int KategorieID);
    }
}
