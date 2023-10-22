using System;
using System.Numerics;

namespace PERUSTARS.AtEventManagement.Domain.Model.Aggregates
{
    public class Participant
    {
        public long? Id { get; set; }
        public string UserName { get; set; }
        public DateTime RegisterDateTime { get; set; }
        public DateTime CheckInDateTime { get; set; }
        public long? HobystId { get; set; }
        public Hobyst Hobyst { get; set; }
        public ArtEvent ArtEvent { get; set; }
        public long? ArtEventId { get; set; }
        public bool Collected { get; set; }


        public Participant(long id, string userName, DateTime registerDateTime, DateTime checkInDateTime, long? hobystId, long? artEventId, Hobyst hobyst, ArtEvent artEvent, bool collected)
        {
            Id = id;
            UserName = userName;
            RegisterDateTime = registerDateTime;
            CheckInDateTime = checkInDateTime;
            HobystId = hobystId;
            ArtEventId = artEventId;
            Hobyst = hobyst;
            ArtEvent = artEvent;
            Collected = collected;
        }
    }
}
