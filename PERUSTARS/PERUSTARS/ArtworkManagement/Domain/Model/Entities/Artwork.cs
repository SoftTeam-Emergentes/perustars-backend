using System;
using System.Collections.Generic;
using PERUSTARS.ArtworkManagement.Domain.Model.Enumerations;
using PERUSTARS.ArtworkManagement.Domain.Model.ValueObjects;

namespace PERUSTARS.ArtworkManagement.Domain.Model.Entities
{
    public class Artwork
    {
        public long Id { get; set; }
        public Title Title { get; set; }
        public Description Description { get; set; }
        public ArtworkContent MainContent { get; set; }
        public float Price { get; set; }
        public IEnumerable<HobbyistFavoriteArtwork> HobbyistsList { get; set; }
        public ArtworkContent CoverImage { get; set; }
        public IEnumerable<Review> ReviewsList { get; set; }
        public DateTime PublishedAt { get; set; }
        public ArtworkStatus Status { get; set; }
        public long ArtistId { get; set; }
        public Artist Artist { get; set; }

        public Artwork(long id, long artistId, Title title, Description description, ArtworkContent mainContent, float price, IEnumerable<HobbyistFavoriteArtwork> hobbyistsList, ArtworkContent coverImage, IEnumerable<Review> reviewsList, DateTime publishedAt, ArtworkStatus status)
        {
            Id = id;
            ArtistId = artistId;
            Title = title;
            Description = description;
            MainContent = mainContent;
            Price = price;
            HobbyistsList = hobbyistsList;
            CoverImage = coverImage;
            ReviewsList = reviewsList;
            PublishedAt = publishedAt;
            Status = status;
        }
    }
}
