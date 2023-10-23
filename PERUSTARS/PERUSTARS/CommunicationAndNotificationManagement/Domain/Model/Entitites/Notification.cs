using System;
using System.Reflection;
using PERUSTARS.Domain.Models;

namespace PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Entities
{
    public class Notification
    {
        public long id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long ArtistId { get; set; }
        //TODO: public Artist Artist { get; set; }  || COMPARAR SI SE IMPLEMENTA 
        public long HobbyistId { get; set; }
        //TODO: public Hobbyist Hobbyist { get; set; }
        public bool Collected  { get; set; } = false;
    }
}
