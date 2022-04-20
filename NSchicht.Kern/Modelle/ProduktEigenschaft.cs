using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSchicht.Kern
{
    public class ProduktEigenschaft
    {
        public int ID { get; set; }
        public string Farbe { get; set; }
        public int Höhe { get; set; }
        public int Breite { get; set; }
        public int ProduktID { get; set; }
        public Produkt Produkt { get; set; }
    }
}
