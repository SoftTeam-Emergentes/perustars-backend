using PERUSTARS.DataAnalytics.Domain.Model.Enums;
using System;
using System.Numerics;

namespace PERUSTARS.DataAnalytics.Domain.Model.Entities
{
    public class ParticipantEventRegistration
    {
        public BigInteger Id { get; set; }
        public BigInteger HobyistId { get; set; }
        public string EventTitle { get; set; }
        public BigInteger ArtistId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public EventParticipationStatus EventParticipationStatus { get; set; }
    }
}
