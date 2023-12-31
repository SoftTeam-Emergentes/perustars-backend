﻿﻿using System;
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
    public class NotifyEventRescheduledCommandHandler : IRequestHandler<NotifyArtEventRescheduledCommand, bool>
    {
        public readonly IPublisher _publisher;
        private readonly IMapper _mapper;
        private readonly INotificationRepository _notificationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public NotifyEventRescheduledCommandHandler(IPublisher publisher, IMapper mapper, INotificationRepository notificationRepository, IUnitOfWork unitOfWork)
        {
            _publisher = publisher;
            _mapper = mapper;
            _notificationRepository = notificationRepository;
            _unitOfWork = unitOfWork;

        }

        public async Task<bool> Handle(NotifyArtEventRescheduledCommand request, CancellationToken cancellationToken)
        {
            var notification = _mapper.Map<Notification>(request);
            notification.Title = "Se ha reprogramado un evento";
            notification.Description = "Se ha reprogramado un evento en el que estabas participando";
            notification.Sender = NotificationSender.ARTIST;
            notification.SentAt = DateTime.UtcNow;
        
            try
            {   
                await _notificationRepository.AddAsync(notification);
                await _unitOfWork.CompleteAsync();
                await _publisher.Publish(new RescheduledArtEventNotifiedEvent());

            }
            catch (Exception e)
            {
                throw new ApplicationException($"An error occurred while notifying the event that has been rescheduled: {e.Message}");
            }

            return await Task.FromResult(true);
        }
    }
}