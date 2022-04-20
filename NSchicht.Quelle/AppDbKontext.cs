using Microsoft.EntityFrameworkCore;
using NSchicht.Kern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSchicht.Quelle
{
    public class AppDbKontext:DbContext
    {
        public AppDbKontext(DbContextOptions<AppDbKontext> options):base(options)
        {

        }
        public DbSet<Kategorie> Kategorien { get; set; }
        public DbSet<Produkt> Produkte { get; set; }
        public DbSet<ProduktEigenschaft> ProduktEigenschaften { get; set; }
    }
}
