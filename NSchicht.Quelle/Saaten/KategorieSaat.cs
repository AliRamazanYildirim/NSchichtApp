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
    internal class KategorieSaat : IEntityTypeConfiguration<Kategorie>
    {
        public void Configure(EntityTypeBuilder<Kategorie> builder)
        {
            builder.HasData(new Kategorie { ID = 1, Name = "Bleistifte" },
                            new Kategorie { ID = 2, Name = "Bücher" },
                            new Kategorie { ID = 3, Name = "Notizbücher" });
        }
    }
}
