using System.Threading.Tasks;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Aggregates;
using PERUSTARS.Shared.Domain.Repositories;

namespace PERUSTARS.IdentityAndAccountManagement.Domain.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        bool ExistsByEmail(string email);
        Task<User> FindByEmailAsync(string email);
    }
}

