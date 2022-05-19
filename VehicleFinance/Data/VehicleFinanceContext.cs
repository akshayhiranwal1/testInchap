using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using VehicleFinanceAPI.Api.Data;
using VehicleFinanceAPI.Data.Entities;

namespace VehicleFinanceAPI.Data
{
    public partial class VehicleFinanceContext : DbContext, IDbContext
    {
        public VehicleFinanceContext()
        {
        }

        public VehicleFinanceContext(DbContextOptions<VehicleFinanceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FinanceRateRange> FinanceRateRange { get; set; }
        public virtual DbSet<FinanceType> FinanceType { get; set; }
        public virtual DbSet<Make> Make { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }
        public virtual DbSet<VehicleFinanceRateMapping> VehicleFinanceRateMapping { get; set; }
        public virtual DbSet<VehicleType> VehicleType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=TCLC-VM-WIN10-7;database=VehicleFinance;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FinanceRateRange>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FinanceType>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Make>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkFinanceType)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.FkFinanceTypeId)
                    .HasConstraintName("FK_Vehicle_FinanceType");

                entity.HasOne(d => d.FkMake)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.FkMakeId)
                    .HasConstraintName("FK_Vehicle_Make");

                entity.HasOne(d => d.FkVehicleType)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.FkVehicleTypeId)
                    .HasConstraintName("FK_Vehicle_VehicleType");
            });

            modelBuilder.Entity<VehicleFinanceRateMapping>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RateValue).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.FkFinanceRate)
                    .WithMany(p => p.VehicleFinanceRateMapping)
                    .HasForeignKey(d => d.FkFinanceRateId)
                    .HasConstraintName("FK_VehicleFinanceRateMapping_FinanceRateRange");

                entity.HasOne(d => d.FkVehicle)
                    .WithMany(p => p.VehicleFinanceRateMapping)
                    .HasForeignKey(d => d.FkVehicleId)
                    .HasConstraintName("FK_VehicleFinanceRateMapping_Vehicle");
            });

            modelBuilder.Entity<VehicleType>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });
        }
    }
}
