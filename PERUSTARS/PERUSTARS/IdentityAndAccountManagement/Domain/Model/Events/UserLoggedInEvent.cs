using MediatR;

namespace PERUSTARS.IdentityAndAccountManagement.Domain.Model.Events
{
    public class UserLoggedInEvent : INotification
    {
        public long UserId { get; set; }
    }
}

