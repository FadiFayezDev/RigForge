using MotherboardModule.Domain.Entities;
using MotherboardModule.Domain.Primitives.Identifiers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MotherboardModule.Infrastructure.Configurations
{
    public class ChipsetProfileConfiguration : IEntityTypeConfiguration<ChipsetProfile>
    {
        public void Configure(EntityTypeBuilder<ChipsetProfile> builder)
        {
            builder.ToTable("ChipsetProfiles");

            builder.HasKey(chipset => chipset.Id);

            builder.Property(chipset => chipset.Id).HasConversion(
                id => id.Value,
                id => ChipsetProfileId.FromGuid(id));

            builder
                .Property(chipset => chipset.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(chipset => chipset.Manufacturer)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(50);

            // SocketId is a reference to a socket owned by the Socket Module.
            // No FK/navigation: the Socket Module owns its persistence in an
            // isolated DbContext/schema, and the Motherboard Module only stores the id.
            builder
                .Property(chipset => chipset.SocketId)
                .IsRequired();
        }
    }
}
