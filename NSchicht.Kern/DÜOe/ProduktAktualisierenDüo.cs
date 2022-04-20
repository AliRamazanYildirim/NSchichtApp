using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSchicht.Kern.DÜOe
{
    public class ProduktAktualisierenDüo
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Vorrat { get; set; }
        public decimal Preis { get; set; }
        public int KategorieID { get; set; }
    }
}
