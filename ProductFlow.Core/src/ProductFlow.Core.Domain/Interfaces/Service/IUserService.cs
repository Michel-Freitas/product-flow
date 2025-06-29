using ProductFlow.Core.Domain.Entity;

namespace ProductFlow.Core.Domain.Interfaces.Service
{
    public interface IUserService
    {
        Task<UserEntity> InsertAsync(UserEntity entity);
    }
}
