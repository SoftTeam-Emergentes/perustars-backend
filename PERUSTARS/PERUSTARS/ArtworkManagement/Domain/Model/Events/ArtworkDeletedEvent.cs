﻿using MediatR;

namespace PERUSTARS.ArtworkManagement.Domain.Model.Events
{
    public class ArtworkDeletedEvent : INotification
    {
        public long Id { get; set; }
    }
}
