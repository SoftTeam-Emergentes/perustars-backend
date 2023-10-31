using System;
using MediatR;

namespace PERUSTARS.ArtworkManagement.Domain.Model.Events
{
    public class ArtworkReviewedEvent : INotification
    {
        public long Id { get; set; }
        public long ArtworkId { get; set; }
        public long HobbyistId { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDateTime { get; set; }
        public float Calification { get; set; }
    }
}
