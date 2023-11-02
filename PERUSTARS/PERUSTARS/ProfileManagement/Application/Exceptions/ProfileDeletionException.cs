using System;

namespace PERUSTARS.ProfileManagement.Application.Exceptions
{
    public class ProfileDeletionException:Exception
    {
        public ProfileDeletionException() { }
        public ProfileDeletionException(string message) : base(message) { }
        public ProfileDeletionException(string message, Exception inner) : base(message, inner) { }
    }
}