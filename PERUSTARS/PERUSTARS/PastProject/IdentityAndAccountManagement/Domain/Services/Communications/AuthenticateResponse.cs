using System.Numerics;
using PERUSTARS.PastProject.IdentityAndAccountManagement.Domain.Models;

namespace PERUSTARS.PastProject.IdentityAndAccountManagement.Domain.Services.Communications
{
    public class AuthenticateResponse
    {
        public BigInteger Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            Username = user.Username;
            Token = token;
        }
    }
}
