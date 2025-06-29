using ProductFlow.Core.Domain.Entity;

namespace ProductFlow.Core.Domain.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<UserEntity?> GetByEmailAsync(string email);
        Task<UserEntity> InsertAsync(UserEntity entity);
    }
}
