﻿using System;

namespace PERUSTARS.CommunicationAndNotificationManagement.Application.Exceptions
{
    public class NotificationNotSendedException : Exception
    {
        public NotificationNotSendedException() { }
        public NotificationNotSendedException(string message) : base(message) {   }
        public NotificationNotSendedException(string message, Exception inner) : base(message, inner) {   }
        
    }
}