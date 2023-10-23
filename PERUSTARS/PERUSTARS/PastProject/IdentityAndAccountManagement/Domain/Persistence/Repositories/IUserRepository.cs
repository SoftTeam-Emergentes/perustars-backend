using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using PERUSTARS.PastProject.IdentityAndAccountManagement.Domain.Models;

namespace PERUSTARS.PastProject.IdentityAndAccountManagement.Domain.Persistence.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();
        Task AddAsync(User user);
        Task<User> FindByIdAsync(BigInteger id);
        Task<User> FindByUsernameAsync(string username);
        bool ExistsByUsername(string username);
        User FindById(BigInteger id);
        void Update(User user);
        void Remove(User user);
    }
}
