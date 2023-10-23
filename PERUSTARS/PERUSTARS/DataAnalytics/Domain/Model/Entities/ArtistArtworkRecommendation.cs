

using System;

namespace PERUSTARS.DataAnalytics.Domain.Model.Entities
{
    public class ArtistArtworkRecommendation
    {
        public long Id { get; set; }
        public long HobyistId { get; set; }
        public long ArtistId { get; set; }
        public long ArtworkId { get; set; }
        public DateTime RecommendationDateTime { get; set; }
        public bool Collected { get; set; } = false;
    }
}
