using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Commands;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Entities;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Enums;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Events;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Repositories;
using PERUSTARS.CommunicationAndNotificationManagement.Interfaces.REST.Resources;
using PERUSTARS.Shared.Domain.Repositories;

namespace PERUSTARS.CommunicationAndNotificationManagement.Application.Commands.Handlers
{
    public class NotifyEventStartedCommandHandler : IRequestHandler<NotifyArtEventStartedCommand, bool>
    {
        public readonly IPublisher _publisher;
        private readonly IMapper _mapper;
        private readonly INotificationRepository _notificationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public NotifyEventStartedCommandHandler(IPublisher publisher, IMapper mapper, INotificationRepository notificationRepository, IUnitOfWork unitOfWork)
        {
            _publisher = publisher;
            _mapper = mapper;
            _notificationRepository = notificationRepository;
            _unitOfWork = unitOfWork;

        }

        public async Task<bool> Handle(NotifyArtEventStartedCommand request, CancellationToken cancellationToken)
        {
            var notification = _mapper.Map<Notification>(request);
            notification.Title = "Ha empezado un evento";
            notification.Description = "Un evento en el que estabas participando ha comenzado";
            notification.Sender = NotificationSender.ARTIST;
            notification.SentAt = DateTime.UtcNow;
        
            try
            {   
                await _notificationRepository.AddAsync(notification);
                await _unitOfWork.CompleteAsync();
                await _publisher.Publish(new StartedArtEventNotifiedEvent());

            }
            catch (Exception e)
            {
                throw new ApplicationException($"An error occurred while notifying the event that has been shared: {e.Message}");
            }

            return await Task.FromResult(true);
        }
    }
}
