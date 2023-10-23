using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WeatherForecastASPNetCoreDBFirst.Models
{
    public partial class WeatherForecastDBContext : DbContext
    {
        public WeatherForecastDBContext()
        {
        }

        public WeatherForecastDBContext(DbContextOptions<WeatherForecastDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<HavaDurumu> HavaDurumus { get; set; } = null!;
        public virtual DbSet<HavaDurumuIcon> HavaDurumuIcons { get; set; } = null!;
        public virtual DbSet<Kullanicilar> Kullanicilars { get; set; } = null!;
        public virtual DbSet<Sehirler> Sehirlers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=FURKAN\\FURKANKILIC;Database=WeatherForecastDB;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HavaDurumu>(entity =>
            {
                entity.HasKey(e => e.DurumId)
                    .HasName("PK__HavaDuru__E6B16D64CE927202");

                entity.ToTable("HavaDurumu");

                entity.Property(e => e.DurumId).HasColumnName("DurumID");

                entity.Property(e => e.Aciklama).HasMaxLength(100);

                entity.Property(e => e.SehirId).HasColumnName("SehirID");

                entity.Property(e => e.Tarih).HasColumnType("date");

                entity.HasOne(d => d.Sehir)
                    .WithMany(p => p.HavaDurumus)
                    .HasForeignKey(d => d.SehirId)
                    .HasConstraintName("FK_HavaDurumu_Sehirler");
            });

            modelBuilder.Entity<HavaDurumuIcon>(entity =>
            {
                entity.HasKey(e => e.IconId)
                    .HasName("PK__HavaDuru__43C7AD2FA57D028C");

                entity.ToTable("HavaDurumuIcon");

                entity.Property(e => e.IconId).HasColumnName("IconID");

                entity.Property(e => e.Aciklama).HasMaxLength(50);
            });

            modelBuilder.Entity<Kullanicilar>(entity =>
            {
                entity.HasKey(e => e.KullaniciId)
                    .HasName("PK__Kullanic__E011F09B5F13B588");

                entity.ToTable("Kullanicilar");

                entity.Property(e => e.KullaniciId).HasColumnName("KullaniciID");

                entity.Property(e => e.KullaniciAdi).HasMaxLength(50);

                entity.Property(e => e.SifreHash).HasMaxLength(100);
            });

            modelBuilder.Entity<Sehirler>(entity =>
            {
                entity.HasKey(e => e.SehirId)
                    .HasName("PK__Sehirler__D1E8748B0015EF27");

                entity.ToTable("Sehirler");

                entity.Property(e => e.SehirId).HasColumnName("SehirID");

                entity.Property(e => e.Boylam).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.Enlem).HasColumnType("decimal(8, 6)");

                entity.Property(e => e.SehirAdi).HasMaxLength(50);

                entity.Property(e => e.Ulke).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
