using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BrunoSzczuk.Models
{
    public partial class provamarceloContext : DbContext
    {
        public provamarceloContext()
        {
        }

        public provamarceloContext(DbContextOptions<provamarceloContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Custo> Custo { get; set; }
        public virtual DbSet<Destino> Destino { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Server=localhost;Database=provamarcelo;Port=5432;User Id=aplicacao;Password=aplicacao01;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<Custo>(entity =>
            {
                entity.HasKey(e => e.CdCusto)
                    .HasName("pk_custo");

                entity.ToTable("custo");

                entity.Property(e => e.CdCusto)
                    .HasColumnName("cd_custo")
                    .ValueGeneratedNever();

                entity.Property(e => e.CdDestino).HasColumnName("cd_destino");

                entity.Property(e => e.DsCusto)
                    .IsRequired()
                    .HasColumnName("ds_custo")
                    .HasMaxLength(100);

                entity.Property(e => e.TpCusto).HasColumnName("tp_custo");

                entity.Property(e => e.VlCusto)
                    .HasColumnName("vl_custo")
                    .HasColumnType("numeric(15,2)");

                entity.HasOne(d => d.CdDestinoNavigation)
                    .WithMany(p => p.Custo)
                    .HasForeignKey(d => d.CdDestino)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("custo_destino_fk");
            });

            modelBuilder.Entity<Destino>(entity =>
            {
                entity.HasKey(e => e.CdDestino)
                    .HasName("pk_destino");

                entity.ToTable("destino");

                entity.Property(e => e.CdDestino)
                    .HasColumnName("cd_destino")
                    .ValueGeneratedNever();

                entity.Property(e => e.DsDestino)
                    .IsRequired()
                    .HasColumnName("ds_destino")
                    .HasMaxLength(100);

                entity.Property(e => e.DtInicio)
                    .HasColumnName("dt_inicio")
                    .HasColumnType("date");

                entity.Property(e => e.DtTermino)
                    .HasColumnName("dt_termino")
                    .HasColumnType("date");

                entity.Property(e => e.VlTotal)
                    .HasColumnName("vl_total")
                    .HasColumnType("numeric(15,2)");
            });
        }
    }
}
