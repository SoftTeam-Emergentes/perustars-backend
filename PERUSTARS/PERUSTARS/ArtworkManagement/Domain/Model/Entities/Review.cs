using System;
using System.Numerics;

namespace PERUSTARS.ArtworkManagement.Domain.Model.Entities
{
    public class Review
    {
        public BigInteger Id { get; set; }
        public BigInteger ArtworkId { get; set; }
        public BigInteger HobbyistId { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
        public float Calification { get; set; }

        public Review(BigInteger id, BigInteger artworkId, BigInteger hobbyistId, string title, string comment, DateTime reviewDate, float calification)
        {
            Id = id;
            ArtworkId = artworkId;
            HobbyistId = hobbyistId;
            Title = title;
            Comment = comment;
            ReviewDate = reviewDate;
            Calification = calification;
        }
    }
}
