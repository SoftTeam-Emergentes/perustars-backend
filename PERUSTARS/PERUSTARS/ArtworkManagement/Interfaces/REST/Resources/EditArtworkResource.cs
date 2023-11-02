using System;
using PERUSTARS.ArtworkManagement.Domain.Model.Enums;
using PERUSTARS.ArtworkManagement.Domain.Model.ValueObjects;

namespace PERUSTARS.ArtworkManagement.Interfaces.REST.Resources
{
    public class EditArtworkResource
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ArtworkContent MainContent { get; set; }
        public float Price { get; set; }
        public ArtworkContent CoverImage { get; set; }
        public ArtworkStatus Status { get; set; }
    }
}