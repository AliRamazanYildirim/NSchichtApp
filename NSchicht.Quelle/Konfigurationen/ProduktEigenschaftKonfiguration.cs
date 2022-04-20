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
    internal class ProduktEigenschaftKonfiguration : IEntityTypeConfiguration<ProduktEigenschaft>
    {
        public void Configure(EntityTypeBuilder<ProduktEigenschaft> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            builder.HasOne(x => x.Produkt).WithOne(x => x.ProduktEigenschaft).HasForeignKey<ProduktEigenschaft>(x => x.ProduktID);
           
        }
    }
}
