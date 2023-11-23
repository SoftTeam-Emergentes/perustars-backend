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
using Microsoft.Extensions.Logging;


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
        private readonly ILogger<ArtistsController> _logger;
        public ArtistsController(AppDbContext context, IProfileCommandService profileCommandService, IMapper mapper, IMediator mediator, ILogger<ArtistsController> logger)
        {
            _mapper = mapper;
            _profileCommandService = profileCommandService;
            _mediator = mediator;
            _context = context;
            _logger = logger;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterNewProfileArtist([FromBody] RegisterArtistProfile registerArtistProfile)
        {
            _logger.LogInformation("Attempting to register a new artist profile...");
            RegisterProfileArtistCommand registerProfileArtistCommand = _mapper.Map<RegisterArtistProfile, RegisterProfileArtistCommand>(registerArtistProfile);
            ArtistResource artistResource = await _profileCommandService.ExecuteRegisterProfileCommand(registerProfileArtistCommand);
            
            _logger.LogInformation($"New artist profile registered successfully. ArtistId: {artistResource.ArtistId}");
            
            return Ok(artistResource);
        }
        
        [HttpGet("{artistId}")]
        public async Task<IActionResult> GetArtist(long artistId)
        {
            _logger.LogInformation($"Attempting to retrieve artist profile with ArtistId: {artistId}");
            var artist = await _context.Artists.Include(a => a.FollowersArtist)
                .FirstOrDefaultAsync(a => a.ArtistId == artistId);
            if (artist == null)
            {
                _logger.LogInformation($"Artist profile with ArtistId {artistId} not found");
                return NotFound();
            }
            var artistResource = _mapper.Map<Artist, ArtistResource>(artist);

            _logger.LogInformation($"Retrieved artist profile successfully. ArtistId: {artistId}");
            return Ok(artistResource);
        }

        [HttpDelete("{artistId}")]
        public async Task<IActionResult> DeleteProfileArtist(long artistId)
        {
            _logger.LogInformation($"Attempting to delete artist profile with ArtistId: {artistId}");
            DeleteProfileArtistCommand deleteProfileArtistCommand = new DeleteProfileArtistCommand()
            {
                ArtistId = artistId
            };
            
            try
            {
                await _profileCommandService.ExecuteDeleteProfileCommand(deleteProfileArtistCommand);
                var successMessage = "Artist profile was successfully removed";
                _logger.LogInformation($"Artist profile with ArtistId {artistId} deleted successfully");
                return Ok(successMessage);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting artist profile with ArtistId {artistId}: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }


        }

        [HttpPut("{artistId}")]
        public async Task<IActionResult> EditProfileArtist(long artistId, [FromBody]  ArtistEditResource artistResource)
        {
            _logger.LogInformation($"Attempting to edit artist profile with ArtistId: {artistId}");
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
                _logger.LogInformation($"Artist profile with ArtistId {artistId} edited successfully");
                return Ok(editedArtist);
            }
            catch (ProfileNotFoundException)
            {
                _logger.LogInformation($"Artist profile with ArtistId {artistId} not found");
                return NotFound("profile not found");
            }
            catch (ApplicationException ex)
            {
                _logger.LogError($"Error editing artist profile with ArtistId {artistId}: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllArtists()
        {
            _logger.LogInformation("Attempting to retrieve all artists...");
            var result = await _mediator.Send(new GetAllArtistsQuery());
            var response = _mapper.Map<IEnumerable<Artist>, IEnumerable<GetAllArtistsResource>>(result);
            _logger.LogInformation("Retrieved all artists successfully");
            return Ok(response);
        }
    }
}