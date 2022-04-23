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

        public override int SaveChanges()
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BasisEinheit entityReference)
                {
                    switch (item.Entity)
                    {
                        case EntityState.Added:
                            {
                                entityReference.ErstellungsDatum = DateTime.Now;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                entityReference.NeuesDatum = DateTime.Now;
                                break;
                            }


                    }
                }
            }
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BasisEinheit einheitReferenz)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                einheitReferenz.ErstellungsDatum = DateTime.Now;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                Entry(einheitReferenz).Property(x => x.ErstellungsDatum).IsModified = false;

                                einheitReferenz.NeuesDatum = DateTime.Now;
                                break;
                            }


                    }
                }


            }
            return base.SaveChangesAsync(cancellationToken);
        }

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
