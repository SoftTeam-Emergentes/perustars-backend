using System;

namespace PERUSTARS.ArtworkManagement.Interfaces.REST.Resources
{
    public class RegisterArtworkReviewResource
    {
        public string Title { get; set; }
        public string Comment { get; set; }
        public float Calification { get; set; }
    }
}
