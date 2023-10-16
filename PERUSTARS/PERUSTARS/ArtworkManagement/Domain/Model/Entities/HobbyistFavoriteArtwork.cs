using System;

namespace PERUSTARS.ArtworkManagement.Domain.Model.Entities
{
    public class HobbyistFavoriteArtwork
    {
        public BigInteger Id { get; set; }
        public BigInteger ArtworkId { get; set; }
        public BigInteger HobbyistId { get; set; }

    }
}
