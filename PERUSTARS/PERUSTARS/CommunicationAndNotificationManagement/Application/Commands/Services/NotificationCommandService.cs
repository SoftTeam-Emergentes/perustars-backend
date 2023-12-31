﻿﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Commands;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Enums;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Repositories;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Services;
using PERUSTARS.CommunicationAndNotificationManagement.Interfaces.REST.Resources;

namespace PERUSTARS.CommunicationAndNotificationManagement.Application.Commands.Services    
{
    public class NotificationCommandService : INotificationCommandService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly INotificationRepository _notificationRepository;
        

        public NotificationCommandService(IMediator mediator,  INotificationRepository notificationRepository, IMapper mapper)
        {
            _mediator = mediator;
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }
        public async Task<bool> ExecuteNotifyUpdateArtistProfileCommand(NotifyUpdatedArtistProfileCommand updateArtistProfileCommand)
        {
            return await _mediator.Send(updateArtistProfileCommand);
        }

        public async Task<bool> ExecuteNotifyNewArtworkCreatedCommand(NotifyNewArtworkCreatedCommand newArtworkCreatedCommand)
        {
            return await _mediator.Send(newArtworkCreatedCommand);
        }

        public async Task<bool> ExecuteNotifyArtworkSoldCommand(NotifyArtworkSoldCommand artworkSoldCommand)
        {
            return await _mediator.Send(artworkSoldCommand);
        }

        public async Task<bool> ExecuteNotifyFollowedArtistCommand(NotifyFollowedArtistCommand followedArtistCommand)
        {
            return await _mediator.Send(followedArtistCommand);
        }

        public async Task<bool> ExecuteNotifyAppliedPenaltyCommand(NotifyAppliedPenaltyCommand appliedPenaltyCommand)
        {
            return await _mediator.Send(appliedPenaltyCommand);
        }

        public async Task<bool> ExecuteNotifyArtEventCancelledCommand(NotifyArtEventCancelledCommand artEventCancelledCommand)
        {
            return await _mediator.Send(artEventCancelledCommand);
        }

        public async Task<bool> ExecuteNotifyArtEventFinishedCommand(NotifyArtEventFinishedCommand artEventCreatedCommand)
        {
            return await _mediator.Send(artEventCreatedCommand);
        }

        public async Task<bool> ExecuteNotifyArtEventSharedCommand(NotifyArtEventStartedCommand artEventCreatedCommand)
        {
            return await _mediator.Send(artEventCreatedCommand);
        }

        public async Task<bool> ExecuteNotifyArtEventRescheduledCommand(NotifyArtEventRescheduledCommand artEventUpdatedCommand)
        {
            return await _mediator.Send(artEventUpdatedCommand);
        }
        
        //------------------------------------------------------

        public async Task<NotificationResource> ListNotificationsReceivedBydArtistIdAsync(long artistId)
        {
            var notifications = await _notificationRepository.FindbySenderAndArtistIdAsync(NotificationSender.HOBBYIST, artistId);
            var result = _mapper.Map<IEnumerable<NotificationResource>>(notifications);
            return (NotificationResource)result;
            
        }

        public async Task<NotificationResource> ListNotificationsReceivedByHobbyistIdAsync(long hobbyistId)
        {
            var notifications = await _notificationRepository.FindbySenderAndHobbyistIdAsync(NotificationSender.ARTIST, hobbyistId);
            var result = _mapper.Map<IEnumerable<NotificationResource>>(notifications);
            return (NotificationResource)result;
        }   




        
    }
}