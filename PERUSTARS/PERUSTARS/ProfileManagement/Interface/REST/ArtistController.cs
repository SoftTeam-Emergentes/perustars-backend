using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PERUSTARS.ProfileManagement.Domain.Model.Commands;
using PERUSTARS.ProfileManagement.Domain.Model.Services;
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
            ArtistResource artistResource = await _profileCommandService.executeRegisterProfileCommand(registerProfileArtistCommand);
            return Ok(artistResource);
        }
    }
}