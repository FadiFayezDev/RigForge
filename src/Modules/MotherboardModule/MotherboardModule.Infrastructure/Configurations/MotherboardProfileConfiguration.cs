using MotherboardModule.Domain.Entities;
using MotherboardModule.Domain.Primitives.Identifiers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MotherboardModule.Infrastructure.Configurations
{
    public class MotherboardProfileConfiguration : IEntityTypeConfiguration<MotherboardProfile>
    {
        public void Configure(EntityTypeBuilder<MotherboardProfile> builder)
        {
            builder.ToTable("MotherboardProfiles");

            builder.HasKey(motherboard => motherboard.Id);

            builder.Property(motherboard => motherboard.Id).HasConversion(
                id => id.Value,
                id => MotherboardProfileId.FromGuid(id));

            builder
                .Property(motherboard => motherboard.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(motherboard => motherboard.Manufacturer)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(50);

            // SocketId is a reference to a socket owned by the Socket Module.
            // No FK/navigation: the Socket Module owns its persistence in an
            // isolated DbContext/schema, and the Motherboard Module only stores the id.
            builder
                .Property(motherboard => motherboard.SocketId)
                .IsRequired();

            // =========================
            // RAM
            // =========================

            builder
                .Property(motherboard => motherboard.RamSlots)
                .IsRequired();

            builder
                .Property(motherboard => motherboard.RamType)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(20);

            builder
                .Property(motherboard => motherboard.MaxRamCapacityGB)
                .IsRequired();

            // =========================
            // PCIe
            // =========================

            builder
                .Property(motherboard => motherboard.PcieVersion)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(20);

            // =========================
            // Storage
            // =========================

            builder
                .Property(motherboard => motherboard.M2Slots)
                .IsRequired();

            builder
                .Property(motherboard => motherboard.SataPorts)
                .IsRequired();
        }
    }
}
