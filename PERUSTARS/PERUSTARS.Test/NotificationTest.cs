using System;
using MediatR;
using PERUSTARS.ArtworkManagement.Domain.Repositories;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Repositories;

namespace PERUSTARS.Test
{
    public class NotificationTest
    {
        private MockDbContext _context;
        private INotificationRepository  _notificationRepository;
        private IServiceProvider serviceProvider;
        private IMediator _mediator;
        private IArtworkRepository _artworkRepository;
    }

    internal class MockDbContext
    {
    }
}
