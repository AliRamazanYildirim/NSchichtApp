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
    public class ProduktQuelle : GenerischeQuelle<Produkt>, IProduktQuelle
    {
        public ProduktQuelle(AppDbKontext kontext) : base(kontext)
        {
        }

        public async Task<List<Produkt>> RufProdukteMitKategorie()
        {
            return await _kontext.Produkte.Include(x => x.Kategorie).ToListAsync();
        }
    }
}
