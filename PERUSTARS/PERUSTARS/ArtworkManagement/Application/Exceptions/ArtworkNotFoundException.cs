﻿using System;

namespace PERUSTARS.ArtworkManagement.Application.Exceptions
{
    public class ArtworkNotFoundException : Exception
    {
        public ArtworkNotFoundException() {}
        public ArtworkNotFoundException(string message) : base(message) {}
        public ArtworkNotFoundException(string message, Exception inner) : base(message, inner) {}
    }
}
