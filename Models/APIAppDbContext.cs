using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace wsIOT.Models
{
    public partial class APIAppDbContext : DbContext
    {
        public APIAppDbContext()
        {
        }

        public APIAppDbContext(DbContextOptions<APIAppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dispositivo> Dispositivo { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<Medicion> Medicion { get; set; }
        public virtual DbSet<Sensor> Sensor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlite("Datasource=/home/ivan/Documentos/GIT/wsIOT/InternetOfThings");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Dispositivo>(entity =>
            {
                entity.Property(e => e.DispositivoId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.Property(e => e.LogId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Medicion>(entity =>
            {
                entity.Property(e => e.MedicionId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Dispositivo)
                    .WithMany(p => p.Medicion)
                    .HasForeignKey(d => d.DispositivoId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Sensor)
                    .WithMany(p => p.Medicion)
                    .HasForeignKey(d => d.SensorId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Sensor>(entity =>
            {
                entity.Property(e => e.SensorId).ValueGeneratedOnAdd();
            });
        }
    }
}
