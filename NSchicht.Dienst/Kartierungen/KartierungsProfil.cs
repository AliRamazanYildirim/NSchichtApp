using AutoMapper;
using NSchicht.Kern;
using NSchicht.Kern.DÜOe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSchicht.Dienst.Kartierungen
{
    public class KartierungsProfil:Profile
    {
        public KartierungsProfil()
        {
            CreateMap<Produkt, ProduktDüo>().ReverseMap();
            CreateMap<Kategorie, KategorieDüo>().ReverseMap();
            CreateMap<ProduktEigenschaft, ProduktEigenschaftDüo>().ReverseMap();
            CreateMap<ProduktAktualisierenDüo, Produkt>();
        }
    }
}
