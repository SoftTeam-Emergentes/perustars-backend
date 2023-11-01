using System;

namespace PERUSTARS.CommunicationAndNotificationManagement.Interfaces.REST.Resources
{
    public class NotificationResource
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime SentAt { get; set; }
        public bool IsRead { get; set; }
        
    }
}
