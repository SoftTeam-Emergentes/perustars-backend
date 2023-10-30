using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
            HobbyistResource hobbyistResource = await _profileCommandService.executeRegisterProfileCommand(registerProfileHobbyistCommand);
            return Ok(hobbyistResource);
        }
    }
}