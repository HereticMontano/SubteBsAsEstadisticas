using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;


namespace Repository.Models
{
    public partial class SubtedataContext : DbContext
    {
        public SubtedataContext()
        {
        }

        public SubtedataContext(DbContextOptions<SubtedataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Estadoservicio> Estadoservicio { get; set; }
        public virtual DbSet<Linea> Linea { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json");

                IConfiguration Configuration = builder.Build();
                optionsBuilder.UseMySql(Configuration.GetConnectionString("SubteData"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estado>(entity =>
            {
                entity.ToTable("estado");

                entity.Property(e => e.Id).HasColumnType("tinyint(4)");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<Estadoservicio>(entity =>
            {
                entity.ToTable("estadoservicio");

                entity.HasIndex(e => e.IdEstado)
                    .HasName("IdEstado");

                entity.HasIndex(e => e.IdLinea)
                    .HasName("IdLinea");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Descripcion).HasColumnType("varchar(255)");

                entity.Property(e => e.FechaDesde).HasColumnType("datetime");

                entity.Property(e => e.FechaHasta).HasColumnType("datetime");

                entity.Property(e => e.IdEstado).HasColumnType("tinyint(4)");

                entity.Property(e => e.IdLinea).HasColumnType("tinyint(4)");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Estadoservicio)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("estadoservicio_ibfk_2");

                entity.HasOne(d => d.IdLineaNavigation)
                    .WithMany(p => p.Estadoservicio)
                    .HasForeignKey(d => d.IdLinea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("estadoservicio_ibfk_1");
            });

            modelBuilder.Entity<Linea>(entity =>
            {
                entity.ToTable("linea");

                entity.Property(e => e.Id).HasColumnType("tinyint(4)");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnType("char(1)");
            });
        }
    }
}
