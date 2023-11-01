﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Commands;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PERUSTARS.CommunicationAndNotificationManagement.Interfaces.REST
{
    [Route("api/notifications/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationCommandService _notificationService;
        private readonly IMapper _mapper;

        public NotificationController(INotificationCommandService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        //GET  hid

        //GET aid

    }
}
