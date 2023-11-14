using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PERUSTARS.ArtEventManagement.Domain.Model.Aggregates;
using PERUSTARS.ArtEventManagement.Domain.Model.Commads;
using PERUSTARS.ArtEventManagement.Domain.Model.ValueObjects;
using PERUSTARS.ArtEventManagement.Domain.Services.ArtEvent;
using PERUSTARS.ArtEventManagement.Interfaces.REST.Resources;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Attributes;

namespace PERUSTARS.ArtEventManagement.Interfaces.REST
{
    [ApiController]
    [Authorize]
    [Route("/api/v1")]
    public class ArtEventsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IArtEventCommandService _artEventCommandService;
        private readonly IArtEventQueryService _artEventQueryService;
        public ArtEventsController(IMapper mapper, IArtEventCommandService artEventCommandService, IArtEventQueryService artEventQueryService)
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

        [HttpGet("artevents/{id}")]
        public async Task<IActionResult> GetArtEvent(int id)
        {
            ArtEvent artEvent = _artEventQueryService.getArtEventById(id);
            return Ok(artEvent);
        }

        [HttpPatch("artevents/{id}/cancel")]
        public async Task<IActionResult> cancelArtEvent(int id) {
            CancelArtEventCommand cancelArtEventCommand = new CancelArtEventCommand();
            cancelArtEventCommand.id= id;
            string response = await _artEventCommandService.cancelArtEvent(cancelArtEventCommand);
            return Ok(response);
        }
        [HttpPatch("artevents/{id}/start")]
        public async Task<IActionResult> startArtEvent(int id) {
            StartArtEventCommand startArtEventCommand = new StartArtEventCommand();
            startArtEventCommand.id= id;
            string response= await _artEventCommandService.startArtEventCommand(startArtEventCommand);
            return Ok(response);
        }
        [HttpPut("artevents/{id}")]
        public async Task<IActionResult> editArtEvent([FromBody] UpdateArtEventResource updateArtEventResource)
        {
            var editArtEventCommand = _mapper.Map<UpdateArtEventResource, EditArtEventCommand>(updateArtEventResource);
            string response= await _artEventCommandService.editArtEvent(editArtEventCommand);
            return Ok(response);
        }
        [HttpGet("artevents")]
        public async Task<IActionResult> getALlEvents(){
            IEnumerable<ArtEvent> events= _artEventQueryService.getArtEvents();
            return Ok(events);
        }
        [HttpGet("artists/{id}/artevents")]
        public async Task<IActionResult> getByArtist(int id) { 
            IEnumerable<ArtEvent> events= _artEventQueryService.getArtEventByArtistId(id);
            return Ok(events);
        }
        [HttpPost("artevents/{id}/participant")]
        public async Task<IActionResult> createParticipant([FromBody] RegisterParticipantToArtEventCommand registerParticipantToArtEvent) { 
            string response= await _artEventCommandService.registerParticipantToArtEvent(registerParticipantToArtEvent);
            return Ok(response);
        }

        [HttpDelete("artevents/{id}")]
        public async Task<IActionResult> deleteArtEvent(int id) {
            DeleteArtEventCommand deleteArtEventCommand = new DeleteArtEventCommand();
            deleteArtEventCommand.id=id;
            string response = await _artEventCommandService.deleteArtEvent(deleteArtEventCommand);
            return Ok(response);
        }

    }
}
