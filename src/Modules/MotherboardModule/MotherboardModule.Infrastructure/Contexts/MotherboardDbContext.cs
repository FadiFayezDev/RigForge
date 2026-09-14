using MotherboardModule.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MotherboardModule.Infrastructure.Contexts
{
    internal class MotherboardDbContext : DbContext
    {
        public MotherboardDbContext(DbContextOptions<MotherboardDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MotherboardDbContext).Assembly);
            modelBuilder.HasDefaultSchema("MBD");
        }

        public DbSet<MotherboardProfile> MotherboardProfiles { get; set; }
        public DbSet<ChipsetProfile> ChipsetProfiles { get; set; }
    }
}
