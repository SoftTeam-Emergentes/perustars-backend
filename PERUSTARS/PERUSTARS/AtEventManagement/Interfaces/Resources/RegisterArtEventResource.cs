using PERUSTARS.AtEventManagement.Domain.Model.ValueObjects;
using System;

namespace PERUSTARS.AtEventManagement.Interfaces.Resources
{
    public class RegisterArtEventResource
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? StartDateTime { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public bool? IsOnline { get; set; }
        public long ArtistId { get; set; }
        public ArtEventStatus CurrentStatus { get; set; }
        public bool Collected { get; set; }
    }
}
