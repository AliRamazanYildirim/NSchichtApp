using NSchicht.Kern.DÜOe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSchicht.Kern.Dienste
{
    public interface IProduktDienst : IDienst<Produkt>
    {
        Task<List<ProduktMitKategorieDüo>> RufProdukteMitKategorie();
    }
}
