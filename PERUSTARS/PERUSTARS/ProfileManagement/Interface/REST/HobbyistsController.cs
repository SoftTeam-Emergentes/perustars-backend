using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Attributes;
using PERUSTARS.ProfileManagement.Application.Exceptions;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;
using PERUSTARS.ProfileManagement.Domain.Model.Commands;
using PERUSTARS.ProfileManagement.Domain.Services;

using PERUSTARS.ProfileManagement.Interface.REST.Resources;
using PERUSTARS.Shared.Infrastructure.Configuration;

namespace PERUSTARS.ProfileManagement.Interface.REST
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class HobbyistsController: ControllerBase
    {
        private readonly IProfileCommandService _profileCommandService;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        private readonly IMediator _mediator;
        private readonly ILogger<HobbyistsController> _logger;
        public HobbyistsController(IProfileCommandService profileCommandService, IMediator mediator, IMapper mapper, AppDbContext context, ILogger<HobbyistsController> logger)
        {
            _mapper = mapper;
            _profileCommandService = profileCommandService;
            _context = context;
            _mediator = mediator;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RegisterNewProfileHobbyist([FromBody] RegisterHobbyistProfile registerHobbyistProfile)
        {
            _logger.LogInformation("Attempting to register a new hobbyist profile...");
            RegisterProfileHobbyistCommand registerProfileHobbyistCommand = _mapper.Map<RegisterProfileHobbyistCommand>(registerHobbyistProfile);
            HobbyistResource hobbyistResource = await _profileCommandService.ExecuteRegisterProfileCommand(registerProfileHobbyistCommand);
            _logger.LogInformation($"New hobbyist profile registered successfully. HobbyistId: {hobbyistResource.HobbyistId}");
            return Ok(hobbyistResource);
        }
        [HttpGet("{hobbyistId}")]
        public async Task<IActionResult> GetHobbyist(long hobbyistId)
        {
            _logger.LogInformation($"Attempting to retrieve hobbyist profile with HobbyistId: {hobbyistId}");
            var hobbyist = await _context.Hobbyists.Include(a => a.FollowedArtists)
                .FirstOrDefaultAsync(a => a.HobbyistId == hobbyistId);
            if (hobbyist == null)
            {
                _logger.LogInformation($"Hobbyist profile with HobbyistId {hobbyistId} not found");
                return NotFound();
            }
            _logger.LogInformation($"Retrieved hobbyist profile successfully. HobbyistId: {hobbyistId}");
            var hobbyistResource = _mapper.Map<Hobbyist, HobbyistResource>(hobbyist);

            return Ok(hobbyistResource);
        }
        
        [HttpDelete("{hobbyistId}")]
        public async Task<IActionResult> DeleteProfileHobbyist(long hobbyistId)
        {
            _logger.LogInformation($"Attempting to delete hobbyist profile with HobbyistId: {hobbyistId}");
            DeleteProfileHobbyistCommand deleteProfileHobbyistCommand = new DeleteProfileHobbyistCommand()
            {
                HobbyistId = hobbyistId
            };
            
            try
            {
                await _profileCommandService.ExecuteDeleteProfileCommand(deleteProfileHobbyistCommand);
                var successMessage = "Hobbyist profile was successfully removed";
                _logger.LogInformation($"Hobbyist profile with HobbyistId {hobbyistId} deleted successfully");
                return Ok(successMessage);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting hobbyist profile with HobbyistId {hobbyistId}: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }
        
        [HttpPut("{hobbyistId}")]
        public async Task<IActionResult> EditProfileHobbyist(long hobbyistId, [FromBody]  HobbyistEditResource hobbyistResource)
        {
            _logger.LogInformation($"Attempting to edit hobbyist profile with HobbyistId: {hobbyistId}");
            EditProfileHobbyistCommand editProfileHobbyistCommand = new EditProfileHobbyistCommand()
            {
                HobbyistId = hobbyistId,
                Age=hobbyistResource.Age
            };

            try
            {
               HobbyistResource editedHobbyist =
                    await _profileCommandService.ExecuteEditProfileCommand(editProfileHobbyistCommand);
               _logger.LogInformation($"Hobbyist profile with HobbyistId {hobbyistId} edited successfully"); 
               return Ok(editedHobbyist);
            }
            catch (ProfileNotFoundException)
            {
                _logger.LogInformation($"Hobbyist profile with HobbyistId {hobbyistId} not found");
                return NotFound("profile not found");
            }
            catch (ApplicationException ex)
            {
                _logger.LogError($"Error editing hobbyist profile with HobbyistId {hobbyistId}: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}