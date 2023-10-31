<<<<<<< HEAD
using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PERUSTARS.ProfileManagement.Domain.Model.Commands;

=======
>>>>>>> 2fee3da5ad887de408f6ed620d123f3bf2f009cd
namespace PERUSTARS.ProfileManagement.Interface.REST
{
    [ApiController]
    [Route("api/followers")]
    public class FollowerController:ControllerBase
    {
        private readonly IMediator _mediator;

        public FollowerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("follower")]
        public async Task<IActionResult> FollowArtist([FromBody] FollowArtistCommand followArtistCommand)
        {
            try
            {
                await _mediator.Send(followArtistCommand);
                return Ok("The hobbyist has begun to follow the artist.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error could not follow the artist {ex.Message}");
            }
        }
    }
}