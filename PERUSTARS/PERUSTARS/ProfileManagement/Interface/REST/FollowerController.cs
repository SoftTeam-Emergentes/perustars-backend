using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PERUSTARS.ProfileManagement.Domain.Model.Commands;
using PERUSTARS.ProfileManagement.Domain.Services;

namespace PERUSTARS.ProfileManagement.Interface.REST
{
    [ApiController]
    [Route("api/followers")]
    public class FollowerController:ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IProfileCommandService _profileCommandService;

        public FollowerController(IMediator mediator, IProfileCommandService profileCommandService)
        {
            _mediator = mediator;
            _profileCommandService = profileCommandService;
        }

        [HttpPost("follower")]
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
    }
}