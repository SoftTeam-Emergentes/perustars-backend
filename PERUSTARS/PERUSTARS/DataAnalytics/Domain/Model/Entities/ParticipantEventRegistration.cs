using PERUSTARS.DataAnalytics.Domain.Model.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace PERUSTARS.DataAnalytics.Domain.Model.Entities
{
    public class ParticipantEventRegistration
    {
        public long Id { get; set; }
        public long HobyistId { get; set; }
        public string EventTitle { get; set; }
        public long ArtistId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool Collected { get; set; } = false;
    }
}
