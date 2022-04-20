using NSchicht.Kern.ArbeitsEinheiten;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSchicht.Quelle.ArbeitsEinheiten
{
    public class ArbeitsEinheit : IArbeitsEinheit
    {
        private readonly AppDbKontext _kontext;

        public ArbeitsEinheit(AppDbKontext kontext)
        {
            _kontext = kontext;
        }

        public void Verpflichten()
        {
            _kontext.SaveChanges();
        }

        public async Task VerpflichtenAsync()
        {
            await _kontext.SaveChangesAsync();
        }
    }
}
