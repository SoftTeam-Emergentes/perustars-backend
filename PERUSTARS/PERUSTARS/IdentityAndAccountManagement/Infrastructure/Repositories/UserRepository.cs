using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Aggregates;
using PERUSTARS.IdentityAndAccountManagement.Domain.Repositories;
using PERUSTARS.Shared.Infrastructure.Configuration;
using PERUSTARS.Shared.Infrastructure.Repositories;

namespace PERUSTARS.IdentityAndAccountManagement.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext dbContext) : base(dbContext)
        { }

        public bool ExistsByEmail(string email)
        {
            return _dbContext.Users.Any(p => p.Email == email);
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await _dbContext.Users
                .SingleOrDefaultAsync(p => p.Email == email);
        }
    }
}

