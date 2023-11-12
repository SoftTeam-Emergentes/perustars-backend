using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PERUSTARS.ProfileManagement.Application.Exceptions;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;
using PERUSTARS.ProfileManagement.Domain.Model.Commands;
using PERUSTARS.ProfileManagement.Domain.Services;

using PERUSTARS.ProfileManagement.Interface.REST.Resources;
using PERUSTARS.Shared.Infrastructure.Configuration;

namespace PERUSTARS.ProfileManagement.Interface.REST
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class HobbyistController: ControllerBase
    {
        private readonly IProfileCommandService _profileCommandService;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        private readonly IMediator _mediator;
        public HobbyistController(IProfileCommandService profileCommandService, IMediator mediator, IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _profileCommandService = profileCommandService;
            _context = context;
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterNewProfileHobbyist([FromBody] RegisterHobbyistProfile registerHobbyistProfile)
        {
            RegisterProfileHobbyistCommand registerProfileHobbyistCommand = _mapper.Map<RegisterProfileHobbyistCommand>(registerHobbyistProfile);
            HobbyistResource hobbyistResource = await _profileCommandService.ExecuteRegisterProfileCommand(registerProfileHobbyistCommand);
            return Ok(hobbyistResource);
        }
        [HttpGet("{hobbyistId}")]
        public async Task<IActionResult> GetHobbyist(long hobbyistId)
        {
            var hobbyist = await _context.Hobbyists.Include(a => a.FollowedArtists)
                .FirstOrDefaultAsync(a => a.HobbyistId == hobbyistId);
            if (hobbyist == null)
            {
                return NotFound();
            }
            var hobbyistResource = _mapper.Map<Hobbyist, HobbyistResource>(hobbyist);

            return Ok(hobbyistResource);
        }
        
        [HttpDelete("delete/{hobbyistId}")]
        public async Task<IActionResult> DeleteProfileHobbyist(long hobbyistId)
        {
            DeleteProfileHobbyistCommand deleteProfileHobbyistCommand = new DeleteProfileHobbyistCommand()
            {
                HobbyistId = hobbyistId
            };
            
            await _profileCommandService.ExecuteDeleteProfileCommand(deleteProfileHobbyistCommand);
            var successMessage = "Hobbyist profile was successfully removed";
            return Ok(successMessage);


        }
        
        [HttpPut("edit/{hobbyistId}")]
        public async Task<IActionResult> EditProfileHobbyist(long hobbyistId, [FromBody]  HobbyistEditResource hobbyistResource)
        {
            EditProfileHobbyistCommand editProfileHobbyistCommand = new EditProfileHobbyistCommand()
            {
                HobbyistId = hobbyistId,
                Age=hobbyistResource.Age
            };

            try
            {
               HobbyistResource editedHobbyist =
                    await _profileCommandService.ExecuteEditProfileCommand(editProfileHobbyistCommand);
                return Ok(editedHobbyist);
            }
            catch (ProfileNotFoundException)
            {
                return NotFound("profile not found");
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}