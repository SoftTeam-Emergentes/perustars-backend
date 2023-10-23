using PERUSTARS.PastProject.IdentityAndAccountManagement.Domain.Models;

namespace PERUSTARS.PastProject.IdentityAndAccountManagement.Authorization.Handlers.Interfaces;

public interface IJwtHandler
{
    string GenerateToken(User user);
    int? ValidateToken(string token);
}