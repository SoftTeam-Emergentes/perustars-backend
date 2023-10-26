using System;
using PERUSTARS.ArtworkManagement.Domain.Model.ValueObjects;

namespace PERUSTARS.ArtworkManagement.Domain.Model.Entities
{
    public class Review
    {
        public long Id { get; set; }
        public long ArtworkId { get; set; }
        public long HobbyistId { get; set; }
        public Title Title { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
        public float Calification { get; set; }
        public bool Collected { get; set; }

        public Review(long id, long artworkId, long hobbyistId, Title title, string comment, DateTime reviewDate, float calification, bool collected)
        {
            Id = id;
            ArtworkId = artworkId;
            HobbyistId = hobbyistId;
            Title = title;
            Comment = comment;
            ReviewDate = reviewDate;
            Calification = calification;
            Collected = collected;
        }
    }
}
