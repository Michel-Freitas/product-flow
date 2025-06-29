namespace ProductFlow.Core.Domain.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
        Task<int> SaveChangesAsync();
        IFileRepository FileRepository { get; }
        IUserRepository UserRepository { get; }
    }
}
