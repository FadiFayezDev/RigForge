using CPUModule.Domain.Primitives.Identifiers;
using Domain.Entities.Socket;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CPUModule.Infrastructure.Configurations
{
    public class SocketProfileConfiguration : IEntityTypeConfiguration<SocketProfile>
    {
        public void Configure(EntityTypeBuilder<SocketProfile> builder)
        {
            builder.HasKey(socket => socket.Id);

            builder.Property(socket => socket.Id).HasConversion(
                id => id.Value,
                id => SocketProfileId.FromGuid(id));

            builder
                .Property(socket => socket.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(socket => socket.Manufacturer)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(50);
        }
    }
}