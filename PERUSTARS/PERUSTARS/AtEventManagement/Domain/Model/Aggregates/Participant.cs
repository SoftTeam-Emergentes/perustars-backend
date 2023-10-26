using System;
using System.Numerics;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;
using PERUSTARS.ProfileManagement.Domain.Model.Entities;

namespace PERUSTARS.AtEventManagement.Domain.Model.Aggregates
{
    public class Participant
    {
        public long? Id { get; set; }
        public string UserName { get; set; }
        public DateTime RegisterDateTime { get; set; }
        public DateTime CheckInDateTime { get; set; }
        public DateTime ParticipantRegistrationDateTime { get; set; }
        public long? HobystId { get; set; }
        public Hobbyist Hobyst { get; set; }
        public ArtEvent ArtEvent { get; set; }
        public long? ArtEventId { get; set; }
        public bool Collected { get; set; }


        public Participant(long id, string userName, DateTime registerDateTime, DateTime checkInDateTime, long? hobystId, long? artEventId, Hobbyist hobyst, ArtEvent artEvent, bool collected)
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
