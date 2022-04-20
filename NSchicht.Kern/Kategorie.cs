using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSchicht.Kern
{
    public class Kategorie:BasisEinheit
    {
        public string Name { get; set; }
        public ICollection<Produkt> Produkte { get; set; }
    }
}
