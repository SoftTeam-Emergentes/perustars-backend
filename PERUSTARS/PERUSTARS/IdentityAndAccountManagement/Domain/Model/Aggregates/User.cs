using System.Numerics;
using System.Text.Json.Serialization;

namespace PERUSTARS.IdentityAndAccountManagement.Domain.Model.Aggregates
{
    public class User
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string PasswordHash { get; set; }
    }
}