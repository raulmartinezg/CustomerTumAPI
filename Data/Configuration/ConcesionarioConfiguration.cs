using ClientTum.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientTum.Data.Configuration
{
    public class ConcesionarioConfiguration : IEntityTypeConfiguration<ConcesionarioRutum>
    {
        public void Configure(EntityTypeBuilder<ConcesionarioRutum> builder)
        {
            builder.HasKey(e => e.Id)
                    .HasName("PK_SAE.ConcesionarioRuta");

            builder.ToTable("ConcesionarioRuta", "SAE");

            builder.Property(e => e.Id).HasColumnName("Id");

            builder.Property(e => e.ClaveFolioViaje).HasColumnName("ClaveFolioViaje");

            builder.Property(e => e.FolioViaje).HasMaxLength(150);

            builder.Property(e => e.NumeroConcCte).HasMaxLength(150);

            builder.Property(e => e.RazonSocial).HasMaxLength(150);
        }
    }
}
