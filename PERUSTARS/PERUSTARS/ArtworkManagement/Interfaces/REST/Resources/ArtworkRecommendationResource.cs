using System;

namespace PERUSTARS.ArtworkManagement.Interfaces.REST.Resources
{
    public class ArtworkRecommendationResource
    {
        public long Id { get; set; }
        public long HobyistId { get; set; }
        public long ArtistId { get; set; }
        public long ArtworkId { get; set; }
        public DateTime RecommendationDateTime { get; set; }
    }
}
