using Microsoft.EntityFrameworkCore;
using ProductFlow.Core.Domain.Entity;
using ProductFlow.Core.Domain.Interfaces.Repository;
using ProductFlow.Core.Infra.Dao.Context;

namespace ProductFlow.Core.Infra.Dao.Repository
{
    public class UserRepository(AppDbContext appDbContext) : IUserRepository
    {
        private readonly DbSet<UserEntity> _user = appDbContext.User;

        public async Task<UserEntity?> GetByEmailAsync(string email)
        {
            return await _user.FirstOrDefaultAsync(p => p.Email.ToLower() == email.ToLower());
        }

        public async Task<UserEntity> InsertAsync(UserEntity entity)
        {
            return (await _user.AddAsync(entity)).Entity;
        }
    }
}
