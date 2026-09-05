using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingBlocks.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        int SaveChange();

        // Correct spelling — preferred API. Default impl delegates to legacy for backward compatibility.
        int SaveChanges() => SaveChange();

        void BeginTransaction();
        Task BeginTransactionAsync();

        void CommitTransaction();
        Task CommitTransactionAsync();

        void RollbackTransaction();
        Task RollbackTransactionAsync();
    }
}
