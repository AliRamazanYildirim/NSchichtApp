using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSchicht.Kern.Quellen
{
    public interface IProduktQuelle : IGenerischeQuelle<Produkt>
    {
        Task<List<Produkt>> RufProdukteMitKategorie();
    }
}
