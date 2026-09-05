using CPUModule.Domain.Primitives.Identifiers;
using Domain.Entities.CPU;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CPUModule.Infrastructure.Configurations
{
    public class CPUArchitectureConfiguration : IEntityTypeConfiguration<CPUArchitecture>
    {
        public void Configure(EntityTypeBuilder<CPUArchitecture> builder)
        {
            builder.HasKey(architecture => architecture.Id);

            builder.Property(architecture => architecture.Id).HasConversion(
                id => id.Value,
                id => CPUArchitectureId.FromGuid(id));

            builder
                .Property(architecture => architecture.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(architecture => architecture.ProcessNodeNM)
                .IsRequired();

            builder
                .Property(architecture => architecture.Description)
                .HasMaxLength(500);
        }
    }
}