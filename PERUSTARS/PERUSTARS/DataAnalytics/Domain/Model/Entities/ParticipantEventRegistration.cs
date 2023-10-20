using Org.BouncyCastle.Math;
using System;

namespace PERUSTARS.DataAnalytics.Domain.Model.Entities
{
    public class ParticipantEventRegistration
    {
        public BigInteger EventId;
        public BigInteger HobyistId;
        public BigInteger ArtistId;
        public DateTime RegistrationDate;
    }
}
