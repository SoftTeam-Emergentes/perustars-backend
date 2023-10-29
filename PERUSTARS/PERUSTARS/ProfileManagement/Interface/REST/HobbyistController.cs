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
    [Route("api/hobbyist/[controller]")]
    [ApiController]
    public class HobbyistController: ControllerBase
    {
        private readonly IProfileCommandService _profileCommandService;
        private readonly IMapper _mapper;
        public HobbyistController(IProfileCommandService profileCommandService, IMapper mapper)
        {
            _mapper = mapper;
            _profileCommandService = profileCommandService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterNewProfileHobbyist([FromBody] RegisterHobbyistProfile registerHobbyistProfile)
        {
            RegisterProfileHobbyistCommand registerProfileHobbyistCommand = _mapper.Map<RegisterProfileHobbyistCommand>(registerHobbyistProfile);
            HobbyistResource hobbyistResource = await _profileCommandService.ExecuteRegisterProfileCommand(registerProfileHobbyistCommand);
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
        public async Task<IActionResult> EditProfileHobbyist(long hobbyistId, [FromBody]  HobbyistResource hobbyistResource)
        {
            EditProfileHobbyistCommand editProfileHobbyistCommand = new EditProfileHobbyistCommand()
            {
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