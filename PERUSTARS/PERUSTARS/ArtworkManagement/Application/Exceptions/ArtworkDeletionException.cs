using System;

namespace PERUSTARS.ArtworkManagement.Application.Exceptions
{
    public class ArtworkDeletionException : Exception
    {
        public ArtworkDeletionException() {}
        public ArtworkDeletionException(string message) : base(message) {}
        public ArtworkDeletionException(string message, Exception inner) : base(message, inner) {}
    }
}
