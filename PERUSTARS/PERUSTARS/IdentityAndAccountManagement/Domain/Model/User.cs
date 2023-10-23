using PERUSTARS.ProfileManagement.Domain.Model.Entities;

namespace PERUSTARS.IdentityAndAccountManagement.Domain.Model
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public Artist Artist { get; set; }
        public Hobbyist Hobbyist { get; set; }
        
        
    }
}
