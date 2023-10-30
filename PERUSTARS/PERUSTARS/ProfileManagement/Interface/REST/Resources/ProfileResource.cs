using PERUSTARS.IdentityAndAccountManagement.Domain.Model;

namespace PERUSTARS.ProfileManagement.Interface.REST.Resources
{
    public class ProfileResource
    {
        public User User { get; set; }
        public int Age { get; set; }
    }
}