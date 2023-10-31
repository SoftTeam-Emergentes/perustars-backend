using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using PERUSTARS.AtEventManagement.Domain.Model.Aggregates;
using PERUSTARS.AtEventManagement.Domain.Model.Commads;
using PERUSTARS.AtEventManagement.Domain.Model.ValueObjects;
using PERUSTARS.AtEventManagement.Domain.Services.ArtEvent;
using PERUSTARS.AtEventManagement.Interfaces.Resources;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PERUSTARS.AtEventManagement.Interfaces.rest
{
    [Route("/api/v1/artevents")]
    public class ArtEventController : ControllerBase
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
            RegisterArtEventCommand registerArtEventCommand = new RegisterArtEventCommand(registerArtEventResource.Title, registerArtEventResource.Description, registerArtEventResource.StartDateTime
                , location, false, registerArtEventResource.ArtistId, ArtEventStatus.REGISTERED, false);
            string response = await _artEventCommandService.registerArtEventService(registerArtEventCommand);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArtEvent(int id)
        {
            ArtEvent artEvent = _artEventQueryService.getArtEventById(id);
            return Ok(artEvent);
        }

        [HttpPost("cancel/{id}")]
        public async Task<IActionResult> cancelArtEvent(int id) {
            CancelArtEventCommand cancelArtEventCommand = new CancelArtEventCommand();
            cancelArtEventCommand.id= id;
            string response = await _artEventCommandService.cancelArtEvent(cancelArtEventCommand);
            return Ok(response);
        }
        [HttpPut("edit")]
        public async Task<IActionResult> editArtEvent([FromBody] EditArtEventCommand editArtEventCommand)
        {
            string response= await _artEventCommandService.editArtEvent(editArtEventCommand);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> getALlEvents(){
            IEnumerable<ArtEvent> events= _artEventQueryService.getArtEvents();
            return Ok(events);
        }
        [HttpGet("artist/{id}")]
        public async Task<IActionResult> getByArtist(int id) { 
            IEnumerable<ArtEvent> events= _artEventQueryService.getArtEventByArtistId(id);
            return Ok(events);
        }
        [HttpPost("participant")]
        public async Task<IActionResult> createParticipant([FromBody] RegisterParticipantToArtEventCommand registerParticipantToArtEvent) { 
            string response= await _artEventCommandService.registerParticipantToArtEvent(registerParticipantToArtEvent);
            return Ok(response);
        }
    }
}
