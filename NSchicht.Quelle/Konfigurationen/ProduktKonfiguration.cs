using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSchicht.Kern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSchicht.Quelle.Konfigurationen
{
    internal class ProduktKonfiguration : IEntityTypeConfiguration<Produkt>
    {
        public void Configure(EntityTypeBuilder<Produkt> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Vorrat).IsRequired();
            builder.Property(x => x.Preis).IsRequired().HasColumnType("decimal(18,2)");
            builder.ToTable("Produkte");

            builder.HasOne(x => x.Kategorie).WithMany(x => x.Produkte).HasForeignKey(x => x.KategorieID);
        }
    }
}
