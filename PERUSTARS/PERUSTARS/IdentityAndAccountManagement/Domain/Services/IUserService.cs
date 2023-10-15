using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using PERUSTARS.Domain.Services.Communications;
using PERUSTARS.IdentityAndAccountManagement.Domain.Models;
using PERUSTARS.IdentityAndAccountManagement.Domain.Services.Communications;

namespace PERUSTARS.IdentityAndAccountManagement.Domain.Services
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
