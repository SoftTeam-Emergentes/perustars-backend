using System;

namespace PERUSTARS.DataAnalytics.Domain.Model.Entities
{
    public class MLTrainingData
    {
        public long ArtistRecommendationArtistId { get; set; }
        public long ArtistRecommendationHobbyistId { get; set; }
        public DateTime ArtistRecommendationDatetime { get; set; }
        public long FollowerHobyistId { get; set; }
        public DateTime FollowerRegistrationDatetime { get; set; }
        public long EventParticipantHobyistId { get; set; }
        public DateTime EventParticipantRegistrationDatetime { get; set; }
        public long ArtworkReviewHobbyistId { get; set; }
        public DateTime ArtworkReviewRegistrationDatetime { get; set; }
    }
}
