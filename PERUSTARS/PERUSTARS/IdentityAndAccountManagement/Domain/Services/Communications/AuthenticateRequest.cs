using System.ComponentModel.DataAnnotations;

namespace PERUSTARS.IdentityAndAccountManagement.Domain.Services.Communications
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
