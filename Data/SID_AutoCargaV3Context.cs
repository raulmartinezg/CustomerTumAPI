using ClientTum.Data.Configuration;
using ClientTum.Entities;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ClientTum.Data
{
    public partial class SID_AutoCargaV3Context : DbContext
    {
        public SID_AutoCargaV3Context()
        {
        }

        public SID_AutoCargaV3Context(DbContextOptions<SID_AutoCargaV3Context> options)
            : base(options)
        {
        }

        public virtual DbSet<FolioViajeGeneral> FolioViajeGenerals { get; set; }
        public virtual DbSet<ConcesionarioRutum> ConcesionarioRuta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.ApplyConfiguration(new FoliosConfiguration());

            modelBuilder.ApplyConfiguration(new ConcesionarioConfiguration());

        }
    }
}
