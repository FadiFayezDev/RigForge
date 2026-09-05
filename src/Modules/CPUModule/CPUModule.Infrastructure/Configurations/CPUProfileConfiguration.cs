using CPUModule.Domain.Entities;
using CPUModule.Domain.Primitives.Identifiers;
using Domain.Entities.Socket;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CPUModule.Infrastructure.Configurations
{
    public class CPUProfileConfiguration : IEntityTypeConfiguration<CPUProfile>
    {
        public void Configure(EntityTypeBuilder<CPUProfile> builder)
        {
            builder.ToTable("CPUProfiles");

            builder.HasKey(cpu => cpu.Id);

            builder.Property(cpu => cpu.Id).HasConversion(
                id => id.Value,
                id => CPUProfileId.FromGuid(id));

            // =========================
            // Identity
            // =========================

            builder
                .Property(cpu => cpu.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(cpu => cpu.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder
                .Property(cpu => cpu.Manufacturer)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(50);

            builder
                .Property(cpu => cpu.Family)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(50);

            builder
                .Property(cpu => cpu.ArchitectureId)
                .HasConversion(
                    id => id.Value,
                    id => CPUArchitectureId.FromGuid(id));

            builder
                .HasOne(cpu => cpu.Architecture)
                .WithMany()
                .HasForeignKey(cpu => cpu.ArchitectureId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(cpu => cpu.ReleaseYear)
                .IsRequired();

            // =========================
            // Performance
            // =========================

            builder
                .OwnsOne(cpu => cpu.Cores, cores =>
                {
                    cores
                        .Property(c => c.PerformanceCores)
                        .HasColumnName("PerformanceCores")
                        .IsRequired();

                    cores
                        .Property(c => c.EfficiencyCores)
                        .HasColumnName("EfficiencyCores")
                        .IsRequired();
                });

            builder
                .Property(cpu => cpu.Threads)
                .IsRequired();

            builder
                .Property(cpu => cpu.BaseClockGHz)
                .IsRequired()
                .HasColumnType("decimal(5,2)");

            builder
                .Property(cpu => cpu.BoostClockGHz)
                .IsRequired()
                .HasColumnType("decimal(5,2)");

            // =========================
            // Cache
            // =========================

            builder
                .Property(cpu => cpu.L2CacheMB)
                .IsRequired();

            builder
                .Property(cpu => cpu.L3CacheMB)
                .IsRequired();

            // =========================
            // Power & Cooling
            // =========================

            builder
                .Property(cpu => cpu.TDPWatts)
                .IsRequired();

            builder
                .Property(cpu => cpu.CoolerIncluded)
                .IsRequired();

            builder
                .Property(cpu => cpu.IncludedCoolerType)
                .HasConversion<string>()
                .HasMaxLength(50);

            builder
                .Property(cpu => cpu.SupportsOverclocking)
                .IsRequired();

            // =========================
            // Integrated Graphics
            // =========================

            builder
                .Property(cpu => cpu.HasIntegratedGraphics)
                .IsRequired();

            builder
                .Property(cpu => cpu.IntegratedGraphicsModel)
                .HasMaxLength(150);

            // =========================
            // Compatibility
            // =========================

            builder
                .Property(cpu => cpu.SocketId)
                .HasConversion(
                    id => id.Value,
                    id => SocketProfileId.FromGuid(id));

            builder
                .HasOne<SocketProfile>()
                .WithMany()
                .HasForeignKey(cpu => cpu.SocketId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(cpu => cpu.SupportedRamType)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(20);

            builder
                .Property(cpu => cpu.MaxMemorySpeedMHz)
                .IsRequired();

            builder
                .Property(cpu => cpu.MaxMemoryCapacityGB)
                .IsRequired();

            builder
                .Property(cpu => cpu.PCIeVersion)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(20);

            builder
                .Property(cpu => cpu.PCIeLanes)
                .IsRequired();
        }
    }
}