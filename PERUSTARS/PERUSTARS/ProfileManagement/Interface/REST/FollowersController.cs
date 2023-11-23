using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Attributes;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;
using PERUSTARS.ProfileManagement.Domain.Model.Commands;
using PERUSTARS.ProfileManagement.Domain.Model.Queries;
using PERUSTARS.ProfileManagement.Domain.Services;
using PERUSTARS.ProfileManagement.Interface.REST.Resources;

namespace PERUSTARS.ProfileManagement.Interface.REST
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FollowersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IProfileCommandService _profileCommandService;
        private readonly IMapper _mapper;
        private readonly ILogger<FollowersController> _logger;

        public FollowersController(IMediator mediator, IProfileCommandService profileCommandService, IMapper mapper, ILogger<FollowersController> logger)
        {
            _mediator = mediator;
            _profileCommandService = profileCommandService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> FollowArtist([FromBody] FollowArtistCommand followArtistCommand)
        {
            _logger.LogInformation($"Attempting to follow artist. ArtistId: {followArtistCommand.ArtistId}, HobbyistId: {followArtistCommand.HobbyistId}");
            try
            {
                await _profileCommandService.ExecuteFollowArtistCommand(followArtistCommand);

                _logger.LogInformation("Hobbyist has begun to follow the artist successfully");
                //await _mediator.Send(followArtistCommand); //u
                return Ok("The hobbyist has begun to follow the artist.");//u
            }
            catch (Exception ex)//u
            {
                _logger.LogError($"Error following the artist: {ex.Message}");
                return BadRequest($"Error could not follow the artist {ex.Message}");//u
            }
        }
        [HttpGet("artist/{artistId}")]
        public async Task<IActionResult> GetAllFollowersFromArtist(long artistId)
        {
            _logger.LogInformation($"Attempting to retrieve followers for artist. ArtistId: {artistId}");
            var result = await _mediator.Send(new GetAllFollowersByArtistQuery() { ArtistId = artistId });
            var response = _mapper.Map<IEnumerable<Follower>, IEnumerable<FollowerResource>>(result);
            _logger.LogInformation($"Retrieved followers for artist successfully. ArtistId: {artistId}");
            return Ok(response);
        }
        [HttpDelete("hobbyist/{hobbyistId}")]
        public async Task<IActionResult> DeleteFollowerByHobbyistId(long hobbyistId) {
            _logger.LogInformation($"Attempting to delete follower. HobbyistId: {hobbyistId}");
            var response = await _mediator.Send(new DeleteFollowerCommand() { HobbyistId = hobbyistId });
            _logger.LogInformation($"Follower deleted successfully. HobbyistId: {hobbyistId}");
            return Ok(response);
        }
        [HttpGet("artist/hobbyist/{hobbyistId}")]
        public async Task<IActionResult> GetFollowedArtistByHobbyistId(long hobbyistId) {
            _logger.LogInformation($"Attempting to retrieve followed artist for hobbyist. HobbyistId: {hobbyistId}");
            var response = await _mediator.Send(new GetFollowedArtistByHobbyistIdQuery() { HobbyistId = hobbyistId });
            _logger.LogInformation($"Retrieved followed artist for hobbyist successfully. HobbyistId: {hobbyistId}");
            return Ok(response);
        }
    }
}