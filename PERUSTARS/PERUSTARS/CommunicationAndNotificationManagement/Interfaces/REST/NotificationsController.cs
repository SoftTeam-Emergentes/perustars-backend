﻿﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Commands;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Services;
using PERUSTARS.CommunicationAndNotificationManagement.Interfaces.REST.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
  using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Attributes;


  namespace PERUSTARS.CommunicationAndNotificationManagement.Interfaces.REST
{
    [Authorize]
    [Route("api/v1")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationCommandService _notificationCommandService;
        private readonly IMapper _mapper;

        public NotificationsController(INotificationCommandService notificationCommandService, IMapper mapper)
        {
            _notificationCommandService = notificationCommandService;
            _mapper = mapper;
        }

        [HttpGet("artists/{artistId}/notifications")]
        public async Task<IActionResult> GetNotificationsByArtistId(long artistId)
        {
            var notifications = await _notificationCommandService.ListNotificationsReceivedBydArtistIdAsync(artistId);
            var result = _mapper.Map<IEnumerable<NotificationResource>>(notifications);
            
            return Ok(result);
        }

        [HttpGet("hobbyists/{hobbyistId}/notifications")]
        public async Task<IActionResult> GetNotificationsByHobbyistId(long hobbyistId)
        {
            var notifications = await _notificationCommandService.ListNotificationsReceivedByHobbyistIdAsync(hobbyistId);
            var result = _mapper.Map<IEnumerable<NotificationResource>>(notifications);

            return Ok(result);
        }

    }
}