using Microsoft.EntityFrameworkCore;
using NSchicht.Kern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<ProduktEigenschaft>().HasData(new ProduktEigenschaft()
            {
                ID=1,
                Farbe="Schwarz",
                Höhe=30,
                Breite=21,
                ProduktID=1
            },
            new ProduktEigenschaft()
            {
                ID = 2,
                Farbe = "Grün",
                Höhe = 30,
                Breite = 21,
                ProduktID = 2
            });
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
