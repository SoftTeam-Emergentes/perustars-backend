using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;
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

        public Artist? Artist { get; set; }

        public Hobbyist? Hobbyist { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; }
    }
}