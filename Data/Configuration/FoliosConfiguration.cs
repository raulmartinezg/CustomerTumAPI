using ClientTum.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientTum.Data.Configuration
{
    public class FoliosConfiguration : IEntityTypeConfiguration<FolioViajeGeneral>
    {
        public void Configure(EntityTypeBuilder<FolioViajeGeneral> builder)
        {
            builder.HasKey(e => e.ClaveFolioViaje);

            builder.ToTable("FolioViajeGeneral", "SAE");

            builder.Property(e => e.ClaveFolioViaje)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.FolioViaje)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Operador)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Placa)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Ruta)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.SalidaProgramada).HasColumnType("date");

            builder.Property(e => e.Unidad)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
