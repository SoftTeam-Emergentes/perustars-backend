<<<<<<< HEAD
using System.ComponentModel.DataAnnotations.Schema;
=======
using PERUSTARS.IdentityAndAccountManagement.Interfaces.REST.Resources;
>>>>>>> 2fee3da5ad887de408f6ed620d123f3bf2f009cd

namespace PERUSTARS.ProfileManagement.Interface.REST.Resources
{
    public class RegisterHobbyistProfile
    {
        [ForeignKey("User")]
        public long UserId { get; set; }
        public int Age { get; set; }
    }
}