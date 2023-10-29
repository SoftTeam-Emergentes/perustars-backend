using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PERUSTARS.ProfileManagement.Application.Exceptions;
using PERUSTARS.ProfileManagement.Domain.Model.Commands;
using PERUSTARS.ProfileManagement.Domain.Services;
using PERUSTARS.ProfileManagement.Interface.REST.Resources;


namespace PERUSTARS.ProfileManagement.Interface.REST
{
    [Route("api/artists/[controller]")]
    [ApiController]
    public class ArtistController: ControllerBase
    {
        private readonly IProfileCommandService _profileCommandService;
        private readonly IMapper _mapper;
        public ArtistController(IProfileCommandService profileCommandService, IMapper mapper)
        {
            _mapper = mapper;
            _profileCommandService = profileCommandService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterNewProfileArtist([FromBody] RegisterArtistProfile registerArtistProfile)
        {
            RegisterProfileArtistCommand registerProfileArtistCommand = _mapper.Map<RegisterProfileArtistCommand>(registerArtistProfile);
            ArtistResource artistResource = await _profileCommandService.ExecuteRegisterProfileCommand(registerProfileArtistCommand);
            return Ok(artistResource);
        }

        [HttpDelete("delete/{artistId}")]
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

        [HttpPut("edit/{artistId}")]
        public async Task<IActionResult> EditProfileArtist(long artistId, [FromBody]  ArtistResource artistResource)
        {
            EditProfileArtistCommand editProfileArtistCommand = new EditProfileArtistCommand
            {
              Age=artistResource.Age,
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
    }
}