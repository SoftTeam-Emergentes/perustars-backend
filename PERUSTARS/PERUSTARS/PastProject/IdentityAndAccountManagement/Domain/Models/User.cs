using System.Numerics;

namespace PERUSTARS.PastProject.IdentityAndAccountManagement.Domain.Models
{
    public class User
    {
        public BigInteger Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
    }
}
