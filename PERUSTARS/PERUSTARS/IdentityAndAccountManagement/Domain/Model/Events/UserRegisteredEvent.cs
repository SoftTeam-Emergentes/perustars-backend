﻿using MediatR;

namespace PERUSTARS.IdentityAndAccountManagement.Domain.Model.Events
{
    public class UserRegisteredEvent: INotification
    {
        public long UserId { get; set; }
    }
}
