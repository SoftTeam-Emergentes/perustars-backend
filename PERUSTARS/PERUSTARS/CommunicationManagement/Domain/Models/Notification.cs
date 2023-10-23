using System;
using System.Numerics;
using PERUSTARS.Domain.Models;

namespace PERUSTARS
{
    public class Notification
    {
        public BigInteger Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ArtistId { get; set; }
        public int HobbyistId { get; set; }
    }
}
