using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Repository.Models
{
    public partial class subtedataContext : DbContext
    {
        public subtedataContext()
        {
        }

        public subtedataContext(DbContextOptions<subtedataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Estadoservicio> Estadoservicio { get; set; }
        public virtual DbSet<Fechaestadoservicio> Fechaestadoservicio { get; set; }
        public virtual DbSet<Itinerario> Itinerario { get; set; }
        public virtual DbSet<Linea> Linea { get; set; }
        public virtual DbSet<Precalculado> Precalculado { get; set; }
        public virtual DbSet<Tipodia> Tipodia { get; set; }

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

                entity.HasIndex(e => e.IdFecha)
                    .HasName("IdFecha");

                entity.HasIndex(e => e.IdLinea)
                    .HasName("IdLinea");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Descripcion).HasColumnType("varchar(255)");

                entity.Property(e => e.HoraDesde).HasColumnType("time");

                entity.Property(e => e.HoraHasta).HasColumnType("time");

                entity.Property(e => e.IdEstado).HasColumnType("tinyint(4)");

                entity.Property(e => e.IdFecha).HasColumnType("int(11)");

                entity.Property(e => e.IdLinea).HasColumnType("tinyint(4)");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Estadoservicio)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("estadoservicio_ibfk_2");

                entity.HasOne(d => d.IdFechaNavigation)
                    .WithMany(p => p.Estadoservicio)
                    .HasForeignKey(d => d.IdFecha)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("estadoservicio_ibfk_3");

                entity.HasOne(d => d.IdLineaNavigation)
                    .WithMany(p => p.Estadoservicio)
                    .HasForeignKey(d => d.IdLinea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("estadoservicio_ibfk_1");
            });

            modelBuilder.Entity<Fechaestadoservicio>(entity =>
            {
                entity.ToTable("fechaestadoservicio");

                entity.HasIndex(e => e.IdTipoDia)
                    .HasName("IdTipoDia");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.IdTipoDia).HasColumnType("tinyint(4)");

                entity.HasOne(d => d.IdTipoDiaNavigation)
                    .WithMany(p => p.Fechaestadoservicio)
                    .HasForeignKey(d => d.IdTipoDia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fechaestadoservicio_ibfk_1");
            });

            modelBuilder.Entity<Itinerario>(entity =>
            {
                entity.ToTable("itinerario");

                entity.HasIndex(e => e.IdLinea)
                    .HasName("IdLinea");

                entity.HasIndex(e => e.IdTipoDia)
                    .HasName("IdTipoDia");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.FechaItinerario).HasColumnType("date");

                entity.Property(e => e.HoraDesde).HasColumnType("time");

                entity.Property(e => e.HoraHasta).HasColumnType("time");

                entity.Property(e => e.IdLinea).HasColumnType("tinyint(4)");

                entity.Property(e => e.IdTipoDia).HasColumnType("tinyint(4)");

                entity.HasOne(d => d.IdLineaNavigation)
                    .WithMany(p => p.Itinerario)
                    .HasForeignKey(d => d.IdLinea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("itinerario_ibfk_1");

                entity.HasOne(d => d.IdTipoDiaNavigation)
                    .WithMany(p => p.Itinerario)
                    .HasForeignKey(d => d.IdTipoDia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("itinerario_ibfk_2");
            });

            modelBuilder.Entity<Linea>(entity =>
            {
                entity.ToTable("linea");

                entity.Property(e => e.Id).HasColumnType("tinyint(4)");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnType("char(1)");
            });

            modelBuilder.Entity<Precalculado>(entity =>
            {
                entity.ToTable("precalculado");

                entity.HasIndex(e => e.IdFecha)
                    .HasName("IdFecha");

                entity.HasIndex(e => e.IdLinea)
                    .HasName("IdLinea");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.IdFecha).HasColumnType("int(11)");

                entity.Property(e => e.IdLinea).HasColumnType("tinyint(4)");

                entity.Property(e => e.MinutosNormal).HasColumnType("int(11)");

                entity.Property(e => e.MinutosSuspendida).HasColumnType("int(11)");

                entity.HasOne(d => d.IdFechaNavigation)
                    .WithMany(p => p.Precalculado)
                    .HasForeignKey(d => d.IdFecha)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("precalculado_ibfk_2");

                entity.HasOne(d => d.IdLineaNavigation)
                    .WithMany(p => p.Precalculado)
                    .HasForeignKey(d => d.IdLinea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("precalculado_ibfk_1");
            });

            modelBuilder.Entity<Tipodia>(entity =>
            {
                entity.ToTable("tipodia");

                entity.Property(e => e.Id).HasColumnType("tinyint(4)");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnType("varchar(50)");
            });
        }
    }
}
