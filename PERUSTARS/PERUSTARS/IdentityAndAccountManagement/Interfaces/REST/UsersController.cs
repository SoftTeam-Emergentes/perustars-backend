using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Commands;
using PERUSTARS.IdentityAndAccountManagement.Domain.Services;
using PERUSTARS.IdentityAndAccountManagement.Interfaces.REST.Resources;
using System.Threading.Tasks;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Attributes;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Queries;
using System.Collections.Generic;
using MediatR;

namespace PERUSTARS.IdentityAndAccountManagement.Interfaces.REST
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IIdentityAndAccountManagementCommandService _identityAndAccountManagementCommandService;
        private readonly IMediator _mediator;
        public UsersController(IMapper mapper, IIdentityAndAccountManagementCommandService identityAndAccountManagementCommandService, IMediator mediator)
        {
            _mapper = mapper;
            _identityAndAccountManagementCommandService = identityAndAccountManagementCommandService;
            _mediator = mediator;
        }
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterNewUser([FromBody] RegisterUserRequest registerUserRequest)
        {
            RegisterUserCommand registerUserCommand = _mapper.Map<RegisterUserCommand>(registerUserRequest);
            UserResource userResource = await _identityAndAccountManagementCommandService.ExecuteRegisterUserCommand(registerUserCommand);
            return Ok(userResource);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateRequest authenticateRequest)
        {
            LogInUserCommand logInUserCommand = _mapper.Map<LogInUserCommand>(authenticateRequest);
            AuthenticateResponse authenticateResponse =
                await _identityAndAccountManagementCommandService.ExecuteLogInUserCommand(logInUserCommand);
            return Ok(authenticateResponse);
        }

        [AllowAnonymous]
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUserInformation(long userId, [FromBody] UpdateUserRequest updateUserRequest)
        {
            UpdateUserQuery updateUserQuery = new UpdateUserQuery()
            {
                UserId = userId,
                FirstName = updateUserRequest.FirstName,
                LastName = updateUserRequest.LastName
            };
            KeyValuePair<string, long> response = await _mediator.Send(updateUserQuery);
            if(response.Value == 400) return BadRequest(response.Key);
            return Ok(response.Key);
        }
    }
}
