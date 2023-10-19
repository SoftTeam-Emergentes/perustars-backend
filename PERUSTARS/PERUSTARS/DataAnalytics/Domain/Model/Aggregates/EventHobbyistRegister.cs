using Org.BouncyCastle.Math;
using System;

namespace PERUSTARS.DataAnalytics.Domain.Model.Aggregates
{
    public class EventHobbyistRegister
    {
        public BigInteger EventId;
        public BigInteger HobyistId;
        public BigInteger ArtistId;
        public DateTime RegistrationDate;
    }
}
