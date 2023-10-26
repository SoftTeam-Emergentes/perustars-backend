using System;
using System.Numerics;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;

namespace PERUSTARS.AtEventManagement.Domain.Model.Aggregates
{
    public class Participant
    {
        public long? Id { get; set; }
        public string UserName { get; set; }
        public DateTime RegisterDateTime { get; set; }
        public DateTime CheckInDateTime { get; set; }
        public long? HobbyistId { get; set; }
        public Hobbyist Hobbyist { get; set; }
        public ArtEvent ArtEvent { get; set; }
        public long? ArtEventId { get; set; }
        public bool Collected { get; set; }


        public Participant(long id, string userName, DateTime registerDateTime, DateTime checkInDateTime, long? hobbyistId, long? artEventId, Hobbyist hobbyist, ArtEvent artEvent, bool collected)
        {
            Id = id;
            UserName = userName;
            RegisterDateTime = registerDateTime;
            CheckInDateTime = checkInDateTime;
            HobbyistId = hobbyistId;
            ArtEventId = artEventId;
            Hobbyist = hobbyist;
            ArtEvent = artEvent;
            Collected = collected;
        }
    }
}
