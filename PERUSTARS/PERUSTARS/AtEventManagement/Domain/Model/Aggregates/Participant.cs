using System;
using System.Numerics;

namespace PERUSTARS.AtEventManagement.Domain.Model.Aggregates
{
    public class Participant
    {
        public BigInteger? Id { get; set; }
        public string UserName { get; set; }
        public DateTime RegisterDateTime { get; set; }
        public DateTime CheckInDateTime { get; set; }
        public BigInteger? HobystId { get; set; }
        public BigInteger? ArtEventId { get; set; }

        public Participant(BigInteger? id, string userName, DateTime registerDateTime, DateTime checkInDateTime, BigInteger? hobystId, BigInteger? artEventId)
        {
            Id = id;
            UserName = userName;
            RegisterDateTime = registerDateTime;
            CheckInDateTime = checkInDateTime;
            HobystId = hobystId;
            ArtEventId = artEventId;
        }
    }
}
