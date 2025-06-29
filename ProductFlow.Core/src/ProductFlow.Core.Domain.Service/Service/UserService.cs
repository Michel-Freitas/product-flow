using ProductFlow.Core.Domain.Entity;
using ProductFlow.Core.Domain.Interfaces.Repository;
using ProductFlow.Core.Domain.Interfaces.Service;

namespace ProductFlow.Core.Domain.Service.Service
{
    public class UserService(IUnitOfWork unitOfWork) : IUserService
    {
        private readonly IUserRepository _repository = unitOfWork.UserRepository;
        public async Task<UserEntity> InsertAsync(UserEntity entity)
        {
            return await _repository.InsertAsync(entity);
        }
    }
}
