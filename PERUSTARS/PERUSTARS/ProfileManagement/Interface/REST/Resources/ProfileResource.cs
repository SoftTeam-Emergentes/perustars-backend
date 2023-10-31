using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Aggregates;

namespace PERUSTARS.ProfileManagement.Interface.REST.Resources
{
    public class ProfileResource
    {
        public User User { get; set; }
        public int Age { get; set; }
    }
}