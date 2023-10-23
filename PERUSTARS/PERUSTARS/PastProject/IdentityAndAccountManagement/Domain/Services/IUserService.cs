using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using PERUSTARS.PastProject.IdentityAndAccountManagement.Domain.Models;
using PERUSTARS.PastProject.IdentityAndAccountManagement.Domain.Services.Communications;

namespace PERUSTARS.PastProject.IdentityAndAccountManagement.Domain.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> ListAsync();
        Task<User> GetByIdAsync(BigInteger id);
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
        Task RegisterAsync(RegisterRequest request);
    
        Task<User> FindByUsernameAsync(string username);
        Task UpdateAsync(BigInteger id, UpdateRequest request);
        Task DeleteAsync(BigInteger id);
    }
}
