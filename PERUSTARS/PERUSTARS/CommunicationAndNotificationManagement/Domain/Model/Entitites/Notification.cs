using System;
using System.Reflection;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Enums;
using PERUSTARS.Domain.Models;

namespace PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Entities
{
    public class Notification
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long ArtistId { get; set; }
        public long HobbyistId { get; set; }
        public NotificationSender Sender { get; set; } //Indica si la notificación fue enviada por un artista o un aficionado
        public DateTime SentAt { get; set; } //Fecha en la que se envió la notificación
        public bool IsRead { get; set; } = false; //Indica si la notificación fue leída
        public bool Collected  { get; set; } = false;
    }
}
