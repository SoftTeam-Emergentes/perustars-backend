

using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;

namespace PERUSTARS.IdentityAndAccountManagement.Domain.Model
{
    public class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; }

        
        public Artist? artist { get; set; }
    }
}
