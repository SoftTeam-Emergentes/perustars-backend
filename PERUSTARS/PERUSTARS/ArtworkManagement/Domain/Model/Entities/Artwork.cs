using System;
using System.Collections.Generic;
using PERUSTARS.ArtworkManagement.Domain.Model.Enums;
using PERUSTARS.ArtworkManagement.Domain.Model.ValueObjects;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;

namespace PERUSTARS.ArtworkManagement.Domain.Model.Entities
{
    public class Artwork
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ArtworkContent MainContent { get; set; }
        public float Price { get; set; }
        public IEnumerable<HobbyistFavoriteArtwork> LikedHobbyistsList { get; set; }
        public ArtworkContent CoverImage { get; set; }
        public IEnumerable<ArtworkReview> ReviewsList { get; set; }
        public DateTime PublishedAt { get; set; }
        public ArtworkStatus Status { get; set; }
        public long ArtistId { get; set; }
        public Artist Artist { get; set; }
        public IEnumerable<ArtworkRecommendation> ArtworkRecommendations { get; set; }

        public Artwork(long id, long artistId, string title, string description, ArtworkContent mainContent, float price, IEnumerable<HobbyistFavoriteArtwork> hobbyistsList, ArtworkContent coverImage, IEnumerable<ArtworkReview> reviewsList, DateTime publishedAt, ArtworkStatus status)
        {
            Id = id;
            ArtistId = artistId;
            Title = title;
            Description = description;
            MainContent = mainContent;
            Price = price;
            LikedHobbyistsList = hobbyistsList;
            CoverImage = coverImage;
            ReviewsList = reviewsList;
            PublishedAt = publishedAt;
            Status = status;
        }
    }
}
