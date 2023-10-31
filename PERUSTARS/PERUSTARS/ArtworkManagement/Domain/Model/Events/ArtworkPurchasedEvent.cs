using System;
using MediatR;
using PERUSTARS.ArtworkManagement.Domain.Model.Enums;
using PERUSTARS.ArtworkManagement.Domain.Model.ValueObjects;

namespace PERUSTARS.ArtworkManagement.Domain.Model.Events
{
    public class ArtworkPurchasedEvent : INotification
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ArtworkContent MainContent { get; set; }
        public float Price { get; set; }
        public ArtworkContent CoverImage { get; set; }
        public DateTime PublishedAt { get; set; }
        public ArtworkStatus Status { get; set; }
        public long ArtistId { get; set; }
    }
}
