using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Services;
using PERUSTARS.CommunicationAndNotificationManagement.Interfaces.REST.Resources;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Attributes;
using PERUSTARS.ProfileManagement.Application.Exceptions;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;
using PERUSTARS.ProfileManagement.Domain.Model.Commands;
using PERUSTARS.ProfileManagement.Domain.Model.Queries;
using PERUSTARS.ProfileManagement.Domain.Services;
using PERUSTARS.ProfileManagement.Interface.REST.Resources;
using PERUSTARS.Shared.Infrastructure.Configuration;


namespace PERUSTARS.ProfileManagement.Interface.REST
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ArtistsController: ControllerBase
    {
        private readonly IProfileCommandService _profileCommandService;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly AppDbContext _context;
        public ArtistsController(AppDbContext context, IProfileCommandService profileCommandService, IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _profileCommandService = profileCommandService;
            _mediator = mediator;
            _context = context;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterNewProfileArtist([FromBody] RegisterArtistProfile registerArtistProfile)
        {
            RegisterProfileArtistCommand registerProfileArtistCommand = _mapper.Map<RegisterArtistProfile, RegisterProfileArtistCommand>(registerArtistProfile);
            ArtistResource artistResource = await _profileCommandService.ExecuteRegisterProfileCommand(registerProfileArtistCommand);
            return Ok(artistResource);
        }
        
        [HttpGet("{artistId}")]
        public async Task<IActionResult> GetArtist(long artistId)
        {
            var artist = await _context.Artists.Include(a => a.FollowersArtist)
                .FirstOrDefaultAsync(a => a.ArtistId == artistId);
            if (artist == null)
            {
                return NotFound();
            }
            var artistResource = _mapper.Map<Artist, ArtistResource>(artist);

            return Ok(artistResource);
        }

        [HttpDelete("{artistId}")]
        public async Task<IActionResult> DeleteProfileArtist(long artistId)
        {
            DeleteProfileArtistCommand deleteProfileArtistCommand = new DeleteProfileArtistCommand()
            {
                ArtistId = artistId
            };
            
                await _profileCommandService.ExecuteDeleteProfileCommand(deleteProfileArtistCommand);
                var successMessage = "Artist profile was successfully removed";
                return Ok(successMessage);


        }

        [HttpPut("{artistId}")]
        public async Task<IActionResult> EditProfileArtist(long artistId, [FromBody]  ArtistEditResource artistResource)
        {
            EditProfileArtistCommand editProfileArtistCommand = new EditProfileArtistCommand
            {
                ArtistId = artistId,
                BrandName = artistResource.BrandName,
              Age=artistResource.Age,
              SocialMediaLink = artistResource.SocialMediaLink,
              Description = artistResource.Description,
              Phrase = artistResource.Phrase,
              ContactNumber = artistResource.ContactNumber,
              ContactEmail = artistResource.ContactEmail
            };

            try
            {
                ArtistResource editedArtist =
                    await _profileCommandService.ExecuteEditProfileCommand(editProfileArtistCommand);
                return Ok(editedArtist);
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

        [HttpGet]
        public async Task<IActionResult> GetAllArtists()
        {
            
            var result = await _mediator.Send(new GetAllArtistsQuery());
            var response = _mapper.Map<IEnumerable<Artist>, IEnumerable<GetAllArtistsResource>>(result);
            return Ok(response);
        }
    }
}