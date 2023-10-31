using System;
using PERUSTARS.ArtworkManagement.Domain.Model.Aggregates;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;

namespace PERUSTARS.ArtworkManagement.Domain.Model.Entities
{
    public class ArtworkReview
    {
        public long Id { get; set; }
        public long ArtworkId { get; set; }
        public Artwork Artwork { get; set; }
        public long HobbyistId { get; set; }
        public Hobbyist Hobbyist { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDateTime { get; set; }
        public float Calification { get; set; }
        public bool Collected { get; set; }

        public ArtworkReview(long id, long artworkId, long hobbyistId, string title, string comment, DateTime reviewDate, float calification, bool collected)
        {
            Id = id;
            ArtworkId = artworkId;
            HobbyistId = hobbyistId;
            Title = title;
            Comment = comment;
            ReviewDateTime = reviewDate;
            Calification = calification;
            Collected = collected;
        }
    }
}
