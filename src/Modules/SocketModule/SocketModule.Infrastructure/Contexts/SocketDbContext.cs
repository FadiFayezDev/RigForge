using SocketModule.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocketModule.Infrastructure.Contexts
{
    internal class SocketDbContext : DbContext
    {
        public SocketDbContext(DbContextOptions<SocketDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SocketDbContext).Assembly);
            modelBuilder.HasDefaultSchema("SKT");
        }

        public DbSet<SocketProfile> SocketProfiles { get; set; }
    }
}
