using PERUSTARS.DataAnalytics.Domain.Model.Enums;

namespace PERUSTARS.DataAnalytics.Domain.Model.Entities
{
    public class MLTrainingData
    {
        public long Id { get; set; }
        public long HobbyistId { get; set; }
        public long ArtistId { get; set; }
        public long Score { get; set; }
        public InteractionType InteractionType { get; set; }
        public bool Collected { get; set; }
    }
}
