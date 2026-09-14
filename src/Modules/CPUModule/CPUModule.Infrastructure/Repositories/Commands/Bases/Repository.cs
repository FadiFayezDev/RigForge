using BuildingBlocks.Application.Common.Interfaces;
using BuildingBlocks.Domain.Bases;
using CPUModule.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CPUModule.Infrastructure.Repositories.Commands.Bases
{
    internal class Repository<T, TKey> : IRepository<T, TKey> where T : Entity<TKey>

    {
        private readonly DbSet<T> _context;

        public Repository(CpuDbContext context)
        {
            _context = context.Set<T>();
        }

        // FindAsync applies the key's value conversion (strongly-typed IDs are
        // stored as Guids) and reuses tracked entities — unlike an
        // EqualityComparer-based predicate, which EF cannot translate.
        public async Task<T?> GetByIdAsync(TKey id)
            => await _context.FindAsync(id);

        public async Task<IEnumerable<T>> ListAllAsync()
            => await _context.ToListAsync();

        public async Task AddAsync(T model)
        {
            _context.Add(model);
        }

        public async Task RemoveAsync(T model)
        {
            _context.Remove(model);
        }

        public async Task UpdateAsync(T model)
        {
            _context.Update(model);
        }
    }
}