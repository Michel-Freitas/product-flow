using Microsoft.EntityFrameworkCore.Storage;
using ProductFlow.Core.Domain.Interfaces.Repository;
using ProductFlow.Core.Infra.Dao.Context;

namespace ProductFlow.Core.Infra.Dao.UnitOfWork
{
    public class UnitOfWork(
        AppDbContext dbContext,
        IFileRepository fileRepository,
        IUserRepository userRepository
    ) : IUnitOfWork
    {
        private readonly AppDbContext _context = dbContext;
        private IDbContextTransaction? _transaction;

        public IFileRepository FileRepository { get; } = fileRepository;
        public IUserRepository UserRepository { get; } = userRepository;

        public async Task BeginTransactionAsync()
        {
            if (_transaction != null) return;
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            if (_transaction == null)
                throw new InvalidOperationException("Transação não iniciada.");

            await SaveChangesAsync();
            await _transaction.CommitAsync();
            await DisposeTransactionAsync();
        }

        public async Task RollbackAsync()
        {
            if (_transaction == null)
                throw new InvalidOperationException("Transação não iniciada.");

            await _transaction.RollbackAsync();
            await DisposeTransactionAsync();
        }

        private async Task DisposeTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
