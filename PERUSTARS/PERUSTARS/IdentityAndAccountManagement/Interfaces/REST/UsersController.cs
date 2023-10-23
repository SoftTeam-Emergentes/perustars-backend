﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Commands;
using PERUSTARS.IdentityAndAccountManagement.Domain.Services;
using PERUSTARS.IdentityAndAccountManagement.Interfaces.REST.Resources;
using System.Threading.Tasks;

namespace PERUSTARS.IdentityAndAccountManagement.Interfaces.REST
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IIdentityAndAccountManagementCommandService _identityAndAccountManagementCommandService;
        public UsersController(IMapper mapper, IIdentityAndAccountManagementCommandService identityAndAccountManagementCommandService)
        {
            _mapper = mapper;
            _identityAndAccountManagementCommandService = identityAndAccountManagementCommandService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterNewUser([FromBody] RegisterUserRequest registerUserRequest)
        {
            RegisterUserCommand registerUserCommand = _mapper.Map<RegisterUserCommand>(registerUserRequest);
            UserResource userResource = await _identityAndAccountManagementCommandService.executeRegisterUserCommand(registerUserCommand);
            return Ok(userResource);
        }
    }
}
