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
    [Route("api/v1/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationCommandService _notificationCommandService;
        private readonly IMapper _mapper;

        [HttpGet("artist/{artistId}")]
        public async Task<IActionResult> GetNotificationsByArtistId(long artistId)
        {
            var notifications = await _notificationCommandService.ListNotificationsReceivedBydArtistIdAsync(artistId);
            var result = _mapper.Map<IEnumerable<NotificationResource>>(notifications);
            
            return Ok(result);
        }

        [HttpGet("hobbyist/{hoobyistId}")]
        public async Task<IActionResult> GetNotificationsByHobbyistId(long hoobyistId)
        {
            var notifications = await _notificationCommandService.ListNotificationsReceivedByHobbyistIdAsync(hoobyistId);
            var result = _mapper.Map<IEnumerable<NotificationResource>>(notifications);

            return Ok(result);
        }

    }
}