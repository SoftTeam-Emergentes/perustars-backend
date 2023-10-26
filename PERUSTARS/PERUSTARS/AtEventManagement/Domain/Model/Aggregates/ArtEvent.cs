using System;
using System.Collections.Generic;
using PERUSTARS.AtEventManagement.Domain.Model.ValueObjects;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;

namespace PERUSTARS.AtEventManagement.Domain.Model.Aggregates
{
    public class ArtEvent
    {
        public long? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? StartDateTime { get; set; }
        public Location Location { get; set; }
        public bool? IsOnline { get; set; }
        public long? ArtistId { get; set; }
        public Artist Artist { get; set; }
        public ArtEventStatus? CurrentStatus { get; set; }
        public IEnumerable<Participant> Participants { get; set; }
        public bool Collected { get; set; }

        public ArtEvent(long id, string title, string description, DateTime? startDateTime, Location location, bool? isOnline, long artistId, ArtEventStatus? currentStatus, IEnumerable<Participant> participants, Artist artist, bool collected)
        {
            Id = id;
            Title = title;
            Description = description;
            StartDateTime = startDateTime;
            Location = location;
            IsOnline = isOnline;
            ArtistId = artistId;
            CurrentStatus = currentStatus;
            Participants = participants;
            Artist = artist; ;
            Collected = collected;
        }
    }
}
