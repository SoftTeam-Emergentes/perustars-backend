using System.ComponentModel.DataAnnotations;

namespace PERUSTARS.PastProject.IdentityAndAccountManagement.Domain.Services.Communications
{
    public class RegisterRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
