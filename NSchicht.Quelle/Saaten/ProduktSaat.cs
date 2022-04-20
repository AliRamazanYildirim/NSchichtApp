using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSchicht.Kern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSchicht.Quelle.Saaten
{
    internal class ProduktSaat : IEntityTypeConfiguration<Produkt>
    {
        public void Configure(EntityTypeBuilder<Produkt> builder)
        {
            builder.HasData(new Produkt
            {
                ID=1,
                KategorieID=1,
                Name="Aspekte Neu B2+",
                Preis=100,
                Vorrat=100,
                ErstellungsDatum=DateTime.Now,

            },
            new Produkt
            {
                ID = 2,
                KategorieID = 1,
                Name = "Aspekte Neu C1",
                Preis = 110,
                Vorrat = 100,
                ErstellungsDatum = DateTime.Now,

            },
            new Produkt
            {
                ID = 3,
                KategorieID = 1,
                Name = "Aspekte Neu C2",
                Preis = 135,
                Vorrat = 100,
                ErstellungsDatum = DateTime.Now,

            },
            new Produkt
            {
                ID = 4,
                KategorieID = 2,
                Name = "Rotring 800+ 0.7mm",
                Preis = 85,
                Vorrat = 100,
                ErstellungsDatum = DateTime.Now,

            },
            new Produkt
            {
                ID = 5,
                KategorieID = 2,
                Name = "Rotring 600 0.5mm",
                Preis = 55,
                Vorrat = 100,
                ErstellungsDatum = DateTime.Now,

            }
            );
        }
    }
}
