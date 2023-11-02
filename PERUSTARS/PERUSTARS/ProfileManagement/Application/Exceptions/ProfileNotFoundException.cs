using System;

namespace PERUSTARS.ProfileManagement.Application.Exceptions
{
    public class ProfileNotFoundException : Exception
    {
        public ProfileNotFoundException() { }
        public ProfileNotFoundException(string message) : base(message) { }
        public ProfileNotFoundException(string message, Exception inner) : base(message, inner) { }
    }

}