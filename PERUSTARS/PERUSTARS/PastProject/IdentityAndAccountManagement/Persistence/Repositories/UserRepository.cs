using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using PERUSTARS.PastProject.IdentityAndAccountManagement.Domain.Models;
using PERUSTARS.PastProject.IdentityAndAccountManagement.Domain.Persistence.Context;
using PERUSTARS.PastProject.IdentityAndAccountManagement.Domain.Persistence.Repositories;
using PERUSTARS.Shared.Infrastructure.Repositories;

namespace PERUSTARS.PastProject.IdentityAndAccountManagement.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IAMDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task AddAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
        }

        public async Task<User> FindByIdAsync(BigInteger id)
        {
            return await _dbContext.Users.FindAsync(id);
        }
        
        public async Task<User> FindByUsernameAsync(string username)
        {
            return await _dbContext.Users
                .SingleOrDefaultAsync(p => p.Username == username);
        }

        public bool ExistsByUsername(string username)
        {
            return _dbContext.Users.Any(p => p.Username == username);
        }

        public User FindById(BigInteger id)
        {
            return _dbContext.Users.Find(id);
        }

        public void Update(User user)
        {
            _dbContext.Users.Update(user);
        }

        public void Remove(User user)
        {
            _dbContext.Users.Remove(user);
        }
    }
}
