using PERUSTARS.IdentityAndAccountManagement.Domain.Models;

namespace PERUSTARS.IdentityAndAccountManagement.Authorization.Handlers.Interfaces;

public interface IJwtHandler
{
    string GenerateToken(User user);
    int? ValidateToken(string token);
}