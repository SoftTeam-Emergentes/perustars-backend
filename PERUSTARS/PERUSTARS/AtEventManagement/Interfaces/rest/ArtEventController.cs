using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PERUSTARS.AtEventManagement.Domain.Model.Commads;
using PERUSTARS.AtEventManagement.Domain.Model.ValueObjects;
using PERUSTARS.AtEventManagement.Domain.Services.ArtEvent;
using PERUSTARS.AtEventManagement.Interfaces.Resources;

using System.Threading.Tasks;

namespace PERUSTARS.AtEventManagement.Interfaces.rest
{
    [Route("/api/v1/artevents/[controller]")]
    public class ArtEventController :ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IArtEventCommandService _artEventCommandService;
        private readonly IArtEventQueryService _artEventQueryService;
        public ArtEventController(IMapper mapper, IArtEventCommandService artEventCommandService, IArtEventQueryService artEventQueryService)
        {
            _mapper = mapper;
            _artEventCommandService = artEventCommandService;
            _artEventQueryService = artEventQueryService;
        }
        [HttpPost]
        public async Task<IActionResult> RegisterArtEvent([FromBody] RegisterArtEventResource registerArtEventResource) {
            Location location = new Location(registerArtEventResource.Country, registerArtEventResource.City, registerArtEventResource.Latitude, registerArtEventResource.Longitude);
            RegisterArtEventCommand registerArtEventCommand = new RegisterArtEventCommand(registerArtEventResource.Title,registerArtEventResource.Description,registerArtEventResource.StartDateTime
                ,location,false,registerArtEventResource.ArtistId,ArtEventStatus.REGISTERED,false);
            string response = await _artEventCommandService.registerArtEventService(registerArtEventCommand);
            return Ok(response);
        }
    }
}
