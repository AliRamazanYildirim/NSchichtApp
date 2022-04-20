using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSchicht.Kern
{
    public class Produkt:BasisEinheit
    {
        public string Name { get; set; }
        public int Vorrat { get; set; }
        public decimal Preis { get; set; }
        public int KategorieID { get; set; }
        public Kategorie Kategorie { get; set; }
        public ProduktEigenschaft ProduktEigenschaft { get; set; }
    }
}
