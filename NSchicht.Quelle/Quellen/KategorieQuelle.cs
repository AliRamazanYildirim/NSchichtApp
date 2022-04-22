using Microsoft.EntityFrameworkCore;
using NSchicht.Kern;
using NSchicht.Kern.Quellen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSchicht.Quelle.Quellen
{
    public class KategorieQuelle : GenerischeQuelle<Kategorie>, IKategorieQuelle
    {
        public KategorieQuelle(AppDbKontext kontext) : base(kontext)
        {
        }

        public async Task<Kategorie> RufEinzigeKategorieZurIDMitProdukteAsync(int KategorieID)
        {
            return await _kontext.Kategorien.Include(x => x.Produkte).Where(x => x.ID == KategorieID).SingleOrDefaultAsync();
        }
    }
}
