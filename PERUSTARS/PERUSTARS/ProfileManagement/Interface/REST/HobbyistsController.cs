using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        public HobbyistsController(IProfileCommandService profileCommandService, IMediator mediator, IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _profileCommandService = profileCommandService;
            _context = context;
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RegisterNewProfileHobbyist([FromBody] RegisterHobbyistProfile registerHobbyistProfile)
        {
            RegisterProfileHobbyistCommand registerProfileHobbyistCommand = _mapper.Map<RegisterProfileHobbyistCommand>(registerHobbyistProfile);
            HobbyistResource hobbyistResource = await _profileCommandService.ExecuteRegisterProfileCommand(registerProfileHobbyistCommand);
            return Ok(hobbyistResource);
        }
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetHobbyistByArtistId(long userId)
        {
            List<Hobbyist> hobbyists = await _context.Hobbyists.Where(h => h.UserId == userId).ToListAsync();
            if(hobbyists.Count != 1) return NotFound(new { message = "Hobbyist not found" });
            HobbyistResource hobbyistResource = _mapper.Map<Hobbyist, HobbyistResource>(hobbyists.First());
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
        
        [HttpDelete("{hobbyistId}")]
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
        
        [HttpPut("{hobbyistId}")]
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