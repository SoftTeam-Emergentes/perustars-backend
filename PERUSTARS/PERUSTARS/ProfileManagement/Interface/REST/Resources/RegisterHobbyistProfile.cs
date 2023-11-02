using System.ComponentModel.DataAnnotations.Schema;

namespace PERUSTARS.ProfileManagement.Interface.REST.Resources
{
    public class RegisterHobbyistProfile
    {
        [ForeignKey("User")]
        public long UserId { get; set; }
        public int Age { get; set; }
    }
}