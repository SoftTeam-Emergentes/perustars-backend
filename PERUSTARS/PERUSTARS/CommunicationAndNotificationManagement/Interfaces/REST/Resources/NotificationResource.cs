﻿using System;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Enums;

namespace PERUSTARS.CommunicationAndNotificationManagement.Interfaces.REST.Resources
{
    public class NotificationResource
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime SentAt { get; set; }
        public bool IsRead { get; set; }
        public long ArtistId { get; set; }
        public long HobbyistId { get; set; }
        public NotificationSender Sender { get; set; }
    }
}