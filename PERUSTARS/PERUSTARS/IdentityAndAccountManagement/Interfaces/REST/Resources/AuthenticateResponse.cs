namespace PERUSTARS.IdentityAndAccountManagement.Interfaces.REST.Resources
{
    public class AuthenticateResponse
    {
        public string? Token { get; set; }
        public string Message { get; set; }
        public string? UserType { get; set; }
    }
}

