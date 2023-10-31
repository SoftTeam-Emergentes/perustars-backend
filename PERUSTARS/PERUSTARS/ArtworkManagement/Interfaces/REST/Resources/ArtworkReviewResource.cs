using System;

namespace PERUSTARS.ArtworkManagement.Interfaces.REST.Resources
{
    public class ArtworkReviewResource
    {
        public long Id { get; set; }
        public long ArtworkId { get; set; }
        public long HobbyistId { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDateTime { get; set; }
        public float Calification { get; set; }
    }
}
