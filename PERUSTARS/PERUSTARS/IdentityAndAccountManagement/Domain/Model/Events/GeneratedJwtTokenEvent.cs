using MediatR;

namespace PERUSTARS.IdentityAndAccountManagement.Domain.Model.Events
{
    public class GeneratedJwtTokenEvent : INotification
    {
        public string Token { get; set; }
    }
}

