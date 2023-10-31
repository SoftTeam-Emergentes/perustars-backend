using System;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Entities;

namespace PERUSTARS.CommunicationAndNotificationManagement.Domain.Factories
{
    public class NotificationFactory
    {
        public Notification CreateNotification(string title, string description, long artistId, long hobbyistId)
        {
            Notification notification = new()
            {
                Title = title,
                Description = description,
                ArtistId = artistId,
                HobbyistId = hobbyistId
            };
            return notification;
        }
    }
}
