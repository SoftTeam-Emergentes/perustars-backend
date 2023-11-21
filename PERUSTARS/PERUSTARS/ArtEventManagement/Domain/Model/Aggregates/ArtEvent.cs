using System;
using System.Collections.Generic;
using PERUSTARS.ArtEventManagement.Domain.Model.ValueObjects;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;

namespace PERUSTARS.ArtEventManagement.Domain.Model.Aggregates
{
    public class ArtEvent
    {
        
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? StartDateTime { get; set; }
        public Location Location { get; set; }
        public bool? IsOnline { get; set; }
        public long? ArtistId { get; set; }
        public Artist Artist { get; set; }
        public ArtEventStatus? CurrentStatus { get; set; }
        public IEnumerable<Participant> Participants { get; set; }
        public bool Collected { get; set; }=false;

        public ArtEvent() { }
        public ArtEvent(string title,
            string description,
            DateTime? startDateTime,
            Location Location, bool? isOnline,
            long? artistId,
            Artist Artist) {
            Title = title;
            Description = description;
            StartDateTime = startDateTime;
            this.Location = Location;
            IsOnline = isOnline;
            ArtistId = artistId;
            this.Artist = Artist;
            this.CurrentStatus = ArtEventStatus.REGISTERED;
            this.Participants= new List<Participant>();
        }
        public ArtEvent(long id, 
            string title, 
            string description, 
            DateTime? startDateTime, 
            Location Location, bool? isOnline, 
            long? artistId, 
            Artist Artist, ArtEventStatus? currentStatus, IEnumerable<Participant> Participants, bool collected)
        {
            Id = id;
            Title = title;
            Description = description;
            StartDateTime = startDateTime;
            this.Location = Location;
            IsOnline = isOnline;
            ArtistId = artistId;
            this.Artist = Artist;
            CurrentStatus = currentStatus;
            this.Participants = Participants;
            Collected = collected;
        }
    }
}
