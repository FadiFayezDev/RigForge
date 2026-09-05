using CPUModule.Domain.Entities;
using Domain.Entities.CPU;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CPUModule.Infrastructure.Contexts
{
    internal class CpuDbContext : DbContext
    {
        public CpuDbContext(DbContextOptions<CpuDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CpuDbContext).Assembly);
            modelBuilder.HasDefaultSchema("CPU");
        }

        public DbSet<CPUProfile> CPUs { get; set; }
        public DbSet<CPUArchitecture> CPUArchitectures { get; set; }
    }
}
