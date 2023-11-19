using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
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
    public class FollowersController:ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IProfileCommandService _profileCommandService;
        private readonly IMapper _mapper;

        public FollowersController(IMediator mediator, IProfileCommandService profileCommandService, IMapper mapper)
        {
            _mediator = mediator;
            _profileCommandService = profileCommandService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> FollowArtist([FromBody] FollowArtistCommand followArtistCommand)
        {
            try
            {
               await _profileCommandService.ExecuteFollowArtistCommand(followArtistCommand);
                
                //await _mediator.Send(followArtistCommand); //u
                return Ok("The hobbyist has begun to follow the artist.");//u
            }
            catch (Exception ex)//u
            {
                return BadRequest($"Error could not follow the artist {ex.Message}");//u
            }
        }
        [HttpGet("artist/{artistId}")]
        public async Task<IActionResult> GetAllFollowersFromArtist(long artistId)
        {
            var result = await _mediator.Send(new GetAllFollowersByArtistQuery() { ArtistId = artistId });
            var response = _mapper.Map<IEnumerable<Follower>, IEnumerable<FollowerResource>>(result);
            return Ok(response);
        }
        [HttpDelete("hobbyist/{hobbyistId}")]
        public async Task<IActionResult> DeleteFollowerByHobbyistId(long hobbyistId) {
            var response = await _mediator.Send(new DeleteFollowerCommand() { HobbyistId = hobbyistId });
            return Ok(response);
        }
    }
}